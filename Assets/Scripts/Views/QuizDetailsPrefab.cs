using UnityEngine;
using TMPro;

public class QuizDetailsPrefab : MonoBehaviour {
    [SerializeField] TextMeshProUGUI index;
    [SerializeField] TextMeshProUGUI question;
    int questionIndex;

    public void Setup(int id, string question) {
        this.questionIndex = id;
        this.question.text = question;

        this.index.text = $"{questionIndex + 1}";
    }

    public void OnEditButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.QuestionDetailsPage);
        MainUI.QuestionDetailsPage.OnEditQuestion(questionIndex);
    }

    public void OnDeleteButtonPressed() {
        QuizzesLoader.CurrentQuiz.QuestionList.RemoveAt(questionIndex);
        QuizzesLoader.WriteQuizzesToFile();
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }
}
