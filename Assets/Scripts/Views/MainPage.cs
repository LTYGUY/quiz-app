using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour {
    [SerializeField] Transform quizPrefab;
    [SerializeField] Transform quizzesContainer;

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
        Transform transform = Instantiate(quizPrefab, quizzesContainer);
        MainQuizPrefab newQuiz = transform.GetComponent<MainQuizPrefab>();
        this.spawnedQuizzes.Add(quiz, transform.gameObject);
        this.UpdateQuizIndex();
    }

    void QuizRemoved(Quiz quiz) {
        Destroy(spawnedQuizzes[quiz]);
        this.spawnedQuizzes.Remove(quiz);
        UpdateQuizIndex();
    }

    void UpdateQuizIndex() {
        for (int i = 0; i < this.spawnedQuizzes.Count; i++) {
            KeyValuePair<Quiz, GameObject> spawnedQuiz = this.spawnedQuizzes.ElementAt(i);
            spawnedQuiz.Value
                       .GetComponent<MainQuizPrefab>()
                       .Setup(i, spawnedQuiz.Key);
        }
    }

    public void OnCreateQuizButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.NewQuizPage);
    }
}
