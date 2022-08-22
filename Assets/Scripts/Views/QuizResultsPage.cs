using UnityEngine;
using TMPro;

public class QuizResultsPage : MonoBehaviour {
    [SerializeField] TextMeshProUGUI yourScore;

    void OnEnable() {
        this.yourScore.text = $"Your Score: {QuizPreviewPage.currentScore}/{QuizzesLoader.CurrentQuiz.QuestionList.Count}";
    }

    public void OnBackToMainMenuPressed() {
        MainUI.MoveToPage(MainUIEnum.MainPage);
    }
}
