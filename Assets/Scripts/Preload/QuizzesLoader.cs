using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class QuizzesLoader : MonoBehaviour {
    static string SavePath => $"{Application.persistentDataPath}/quizzes.json";
    public static Quizzes Quizzes { get; private set; }

    void Awake() {
        this.LoadQuizzes();
    }

    void LoadQuizzes() {
        // TODO: Add database sync
        QuizzesLoader.Quizzes = File.Exists(QuizzesLoader.SavePath) ? JsonUtility.FromJson<Quizzes>(File.ReadAllText(QuizzesLoader.SavePath)) : default(Quizzes);
    }

    public static void AddNewQuiz(Quiz quiz) => QuizzesLoader.Quizzes.QuizList.Add(quiz);

    public static void WriteQuizzesToFile() => File.WriteAllText(QuizzesLoader.SavePath, JsonUtility.ToJson(QuizzesLoader.Quizzes));
}
