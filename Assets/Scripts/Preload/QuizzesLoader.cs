using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        StartCoroutine(this.LoadQuizzesFromDatabase($"{QuizzesLoader.ServerURL}quizzes/{SystemInfo.deviceUniqueIdentifier}"));
    }

    void LoadQuizzesLocally() {
        if (!File.Exists(QuizzesLoader.SavePath)) return;
        QuizzesLoader.Quizzes = JsonConvert.DeserializeObject<Quizzes>(File.ReadAllText(QuizzesLoader.SavePath));
        QuizzesLoader.OnQuizzesLoad?.Invoke();
    }

    IEnumerator LoadQuizzesFromDatabase(string URI) {
        bool registered = true;

        using (UnityWebRequest getRequest = UnityWebRequest.Get(URI)) {
            yield return getRequest.SendWebRequest();

            if (getRequest.result == UnityWebRequest.Result.Success) {
                JObject jObject = JObject.Parse(getRequest.downloadHandler.text);
                if (jObject["quizzes"] != null) {
                    jObject.Remove("DeviceID");
                    QuizzesLoader.Quizzes = JsonConvert.DeserializeObject<Quizzes>(jObject["quizzes"].ToString().Replace("\\", ""));
                    QuizzesLoader.OnQuizzesLoad?.Invoke();
                    print("Loaded quizzes from database.");
                }

                else {
                    print("Device is not yet registered.");
                    registered = false;
                }
            }

            else {
                print("Failed to load quizzes from database.");
            }

            if (!registered) this.LoadQuizzesLocally();
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
        JObject jObject = JObject.Parse(json);
        jObject.Add("DeviceID", SystemInfo.deviceUniqueIdentifier);
        WWWForm form = new WWWForm();
        form.AddField("body", jObject.ToString());

        using (UnityWebRequest webRequest = UnityWebRequest.Put(URI, jObject.ToString())) {
            webRequest.method = "POST";
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success) {
                print("Successfully saved to database!");
            }

            else {
                print(webRequest.error);
                QuizzesLoader.WriteQuizToFile();
            }
        }
    }

    public static void WriteQuizToFile() => File.WriteAllText(QuizzesLoader.SavePath, JsonConvert.SerializeObject(QuizzesLoader.Quizzes));
}
