using UnityEngine;
using TMPro;

public class QuizResultsPage : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI yourScore;

    void OnEnable() {
        yourScore.text = $"Your Score: {QuizPreviewPage.currentScore}/{QuizzesLoader.CurrentQuiz.QuestionList.Count}";
    }

    public void OnBackToMainMenuPressed() {
        MainUIs.MoveToPage(MainUIsEnum.MainPage);
    }
}
