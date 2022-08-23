using UnityEngine;
using TMPro;

public class QuizDetailsPage : MonoBehaviour {
    [SerializeField] TextMeshProUGUI quizTitle;
    [SerializeField] Transform questionPrefab;
    [SerializeField] Transform questionsContainer;

    [SerializeField] GameObject previewButton;

    void OnEnable() {
        this.previewButton.SetActive(QuizzesLoader.CurrentQuiz.QuestionList.Count > 0);
        this.quizTitle.text = $"Title: {QuizzesLoader.CurrentQuiz.QuizName}";

        foreach (Transform transform in this.questionsContainer) {
            Destroy(transform.gameObject);
        }

        for (int i = 0; i < QuizzesLoader.CurrentQuiz.QuestionList.Count; i++) {
            Instantiate(questionPrefab, questionsContainer).GetComponent<QuizDetailsPrefab>().Setup(i, QuizzesLoader.CurrentQuiz.QuestionList[i].QuizQuestion);
        }
    }

    public void AddQuestionPressed() {
        MainUI.MoveToPage(MainUIEnum.QuestionDetailsPage);
        MainUI.QuestionDetailsPage.OnEditQuestion(-1);
    }

    public void PreviewQuizPressed() {
        if (QuizzesLoader.CurrentQuiz.QuestionList.Count < 1) return;
        MainUI.MoveToPage(MainUIEnum.QuizPreviewPage);
    }

    public void OnBackButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.MainPage);
    }
}
