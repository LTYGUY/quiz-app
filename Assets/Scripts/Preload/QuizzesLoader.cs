using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

using System;
using UnityEngine;

public class QuizzesLoader : MonoBehaviour {
    static string SavePath => $"{Application.persistentDataPath}/quizzes.json";
    public static Quizzes Quizzes { get; private set; }

    public static Quiz CurrentQuiz { get; private set; }

    public static event Action OnQuizzesLoad;

    public delegate void QuizEvent(Quiz quiz);
    public static event QuizEvent OnNewQuizAdded;

    //in Start because other scripts have not initialised in Awake yet.
    void Start() {
        this.LoadQuizzes();
    }

    void LoadQuizzes() {
        // TODO: Add database sync
        //QuizzesLoader.Quizzes = File.Exists(QuizzesLoader.SavePath) ? JsonConvert.DeserializeObject<Quizzes>(File.ReadAllText(QuizzesLoader.SavePath)) : new Quizzes(new List<Quiz>());

        using (StreamReader file = File.OpenText(QuizzesLoader.SavePath)) {
            JsonSerializer serializer = new JsonSerializer();
            QuizzesLoader.Quizzes = (Quizzes)serializer.Deserialize(file, typeof(Quizzes));
        }
        QuizzesLoader.OnQuizzesLoad?.Invoke();

        CurrentQuiz = QuizzesLoader.Quizzes.QuizList[0];
    }

    public static void AddNewQuiz(Quiz quiz) {
        QuizzesLoader.Quizzes.QuizList.Add(quiz);
        QuizzesLoader.CurrentQuiz = quiz;
        QuizzesLoader.OnNewQuizAdded?.Invoke(quiz);
        WriteQuizzesToFile();
    }

    public static void EditQuiz(int id) {
        CurrentQuiz = Quizzes.QuizList[id];
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }

    public static void WriteQuizzesToFile() => File.WriteAllText(QuizzesLoader.SavePath, JsonConvert.SerializeObject(QuizzesLoader.Quizzes));
}
