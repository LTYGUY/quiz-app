using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class QuizzesLoader : MonoBehaviour {
    const string ServerURL = "https://svcif5fgha.execute-api.ap-southeast-1.amazonaws.com/";
    static string SavePath => $"{Application.persistentDataPath}/quizzes.json";

    public static event Action OnQuizzesSave;
    public static event Action OnQuizzesLoad;
    public static event Action<Quiz> OnNewQuizAdded;
    public static event Action<Quiz> OnQuizDeleted;

    public static Quizzes Quizzes { get; private set; } = new Quizzes(new List<Quiz>());
    public static Quiz CurrentQuiz { get; private set; }

    void Awake() {
        QuizzesLoader.OnQuizzesSave += this.SaveQuizToDatabase;
    }

    void Start() {
        StartCoroutine(this.LoadQuizzesFromDatabase($"{QuizzesLoader.ServerURL}{SystemInfo.deviceUniqueIdentifier}"));
    }

    void LoadQuizzesLocally() {
        if (!File.Exists(QuizzesLoader.SavePath)) return;
        QuizzesLoader.Quizzes = JsonConvert.DeserializeObject<Quizzes>(File.ReadAllText(QuizzesLoader.SavePath));
    }

    IEnumerator LoadQuizzesFromDatabase(string URI) {
        using (UnityWebRequest getRequest = UnityWebRequest.Get(URI)) {
            yield return getRequest.SendWebRequest();

            if (getRequest.result == UnityWebRequest.Result.Success) {
                QuizzesLoader.Quizzes = JsonConvert.DeserializeObject<Quizzes>(getRequest.downloadHandler.text);
            }

            else {
                this.LoadQuizzesLocally();
            }
        }
    }

    public static void AddNewQuiz(Quiz quiz) {
        QuizzesLoader.Quizzes.QuizList.Add(quiz);
        QuizzesLoader.CurrentQuiz = quiz;
        QuizzesLoader.OnNewQuizAdded?.Invoke(quiz);
        SaveQuizzes();
    }

    public static void EditQuiz(int id) {
        CurrentQuiz = Quizzes.QuizList[id];
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }

    public static void DeleteQuiz(Quiz quiz) {
        QuizzesLoader.Quizzes.QuizList.Remove(quiz);
        QuizzesLoader.OnQuizDeleted?.Invoke(quiz);
        SaveQuizzes();

        MainUI.MoveToPage(MainUIEnum.MainPage);
    }

    public static void SaveQuizzes() {
        QuizzesLoader.OnQuizzesSave?.Invoke();
    }

    public void SaveQuizToDatabase() {
        StartCoroutine(this.PostRequest($"{QuizzesLoader.ServerURL}quizzes", JsonConvert.SerializeObject(QuizzesLoader.Quizzes)));
    }

    IEnumerator PostRequest(string URI, string json) {
        using (UnityWebRequest postRequest = UnityWebRequest.Post(URI, json)) {
            yield return postRequest.SendWebRequest();

            if (postRequest.result == UnityWebRequest.Result.Success) {
                print("Successfully saved to database!");
            }

            else {
                print("Failed to save to database!");
                print(postRequest.error);
                QuizzesLoader.WriteQuizToFile();
            }
        }
    }

    public static void WriteQuizToFile() => File.WriteAllText(QuizzesLoader.SavePath, JsonConvert.SerializeObject(QuizzesLoader.Quizzes));
}
