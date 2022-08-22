using UnityEngine;
using TMPro;

public class QuizDetailsPage : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI quizTitle;
    [SerializeField]
    Transform questionPrefab;
    [SerializeField]
    Transform questionsContainer;
    void Awake() {

    }

    void OnEnable() {
        quizTitle.text = $"Title: {QuizzesLoader.CurrentQuiz.QuizName}";

        foreach (Transform t in questionsContainer) {
            Destroy(t.gameObject);
        }

        int i = 1;
        foreach (Question question in QuizzesLoader.CurrentQuiz.QuestionList) {
            Transform t = Instantiate(questionPrefab, questionsContainer);
            QuizDetailsPrefab info = t.GetComponent<QuizDetailsPrefab>();

            info.Setup($"{i}", question.QuizQuestion);

            i++;
        }

    }

    public void AddQuestionPressed() {
        MainUIs.MoveToPage(MainUIsEnum.QuestionDetailsPage);
    }

    public void PreviewQuizPressed() {
        MainUIs.MoveToPage(MainUIsEnum.QuizPreviewPage);
    }
}
