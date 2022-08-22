using UnityEngine;
using TMPro;

public class QuizDetailsPage : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI quizTitle;

    void OnEnabled() {
        quizTitle.text = QuizzesLoader.CurrentQuiz.QuizName;
    }

    public void AddQuestionPressed() {
        MainUIs.MoveToPage(MainUIsEnum.QuestionDetailsPage);
    }

    public void PreviewQuizPressed() {
        MainUIs.MoveToPage(MainUIsEnum.QuizPreviewPage);
    }
}
