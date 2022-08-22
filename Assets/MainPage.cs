using UnityEngine;

public class MainPage : MonoBehaviour {
    [SerializeField] Transform quizPrefab;
    [SerializeField] Transform quizzesContainer;

    void Awake() {
        QuizzesLoader.OnQuizzesLoad += OnQuizzesLoad;
        QuizzesLoader.OnNewQuizAdded += AddNewQuiz;
    }

    void OnQuizzesLoad() {
        QuizzesLoader.Quizzes.QuizList.ForEach(AddNewQuiz);
    }

    void AddNewQuiz(Quiz quiz) {
        Instantiate(quizPrefab, quizzesContainer);
    }

    public void OnCreateQuizButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.NewQuizPage);
    }
}
