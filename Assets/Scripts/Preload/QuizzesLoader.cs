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
        QuizzesLoader.Quizzes = File.Exists(QuizzesLoader.SavePath) ? JsonUtility.FromJson<Quizzes>(File.ReadAllText(QuizzesLoader.SavePath)) : new Quizzes(new List<Quiz>());

        OnQuizzesLoad?.Invoke();
    }

    public static void AddNewQuiz(Quiz quiz) {
        QuizzesLoader.Quizzes.QuizList.Add(quiz);
        CurrentQuiz = quiz;
        OnNewQuizAdded?.Invoke(quiz);
    }

    public static void WriteQuizzesToFile() => File.WriteAllText(QuizzesLoader.SavePath, JsonUtility.ToJson(QuizzesLoader.Quizzes));
}
