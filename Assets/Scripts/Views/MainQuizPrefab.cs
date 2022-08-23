using UnityEngine;
using TMPro;

public class MainQuizPrefab : MonoBehaviour {
    [SerializeField] TextMeshProUGUI index;
    [SerializeField] TextMeshProUGUI quizName;

    Quiz quiz;
    int quizID;

    public void Setup(int id, Quiz quiz) {
        quizID = id;
        index.text = $"{quizID + 1}";

        this.quiz = quiz;
        quizName.text = quiz.QuizName;
    }

    public void OnEditButtonPressed() {
        QuizzesLoader.EditQuiz(quizID);
    }
}
