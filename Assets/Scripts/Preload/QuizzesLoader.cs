using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class QuizzesLoader : MonoBehaviour {
    static string SavePath => $"{Application.persistentDataPath}/quizzes.json";
    public static List<Quiz> Quizzes { get; private set; } = new List<Quiz>();

    void Awake() {
        QuizzesLoader.Quizzes = this.LoadQuizzes();
    }

    public static void AddNewQuiz(Quiz quiz) => Quizzes.Add(quiz);

    public static void WriteQuizzesToFile() => File.WriteAllText(SavePath, JsonUtility.ToJson(QuizzesLoader.Quizzes));

    List<Quiz> LoadQuizzes() => File.Exists(SavePath) ? JsonUtility.FromJson<List<Quiz>>(File.ReadAllText(SavePath)) : new List<Quiz>();
}
