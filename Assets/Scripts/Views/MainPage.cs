using UnityEngine;

public class MainPage : MonoBehaviour {
    [SerializeField] Transform quizPrefab;
    [SerializeField] Transform quizzesContainer;

    int quizID = 0;

    void Awake() {
        QuizzesLoader.OnQuizzesLoad += OnQuizzesLoad;
        QuizzesLoader.OnNewQuizAdded += AddNewQuiz;
    }

    void OnQuizzesLoad() {
        QuizzesLoader.Quizzes.QuizList.ForEach(AddNewQuiz);
    }

    void AddNewQuiz(Quiz quiz) {
        Transform t = Instantiate(quizPrefab, quizzesContainer);
        Main_QuizPrefab newQuiz = t.GetComponent<Main_QuizPrefab>();

        newQuiz.Setup(quizID, quiz);
        quizID++;
    }

    public void OnCreateQuizButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.NewQuizPage);
    }
}
