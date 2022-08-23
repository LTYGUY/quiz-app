using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour {
    [SerializeField] Transform quizPrefab;
    [SerializeField] Transform quizzesContainer;

    int quizID = 0;
    Dictionary<Quiz, GameObject> spawnedQuizzes = new Dictionary<Quiz, GameObject>();

    void Awake() {
        QuizzesLoader.OnQuizzesLoad += OnQuizzesLoad;
        QuizzesLoader.OnNewQuizAdded += AddNewQuiz;
        QuizzesLoader.OnQuizDeleted += QuizRemoved;
    }

    void OnQuizzesLoad() {
        QuizzesLoader.Quizzes.QuizList.ForEach(AddNewQuiz);
    }

    void AddNewQuiz(Quiz quiz) {
        Transform t = Instantiate(quizPrefab, quizzesContainer);
        Main_QuizPrefab newQuiz = t.GetComponent<Main_QuizPrefab>();
        spawnedQuizzes.Add(quiz, t.gameObject);

        newQuiz.Setup(quizID, quiz);
        quizID++;
    }

    void QuizRemoved(Quiz quiz) {
        Destroy(spawnedQuizzes[quiz]);
        spawnedQuizzes.Remove(quiz);

        quizID = 0;
        foreach (KeyValuePair<Quiz, GameObject> spawnedQuiz in spawnedQuizzes) {
            Main_QuizPrefab script = spawnedQuiz.Value.GetComponent<Main_QuizPrefab>();
            script.Setup(quizID, spawnedQuiz.Key);
            quizID++;
        }
    }

    public void OnCreateQuizButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.NewQuizPage);
    }
}
