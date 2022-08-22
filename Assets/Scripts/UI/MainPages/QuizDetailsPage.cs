using UnityEngine;
using TMPro;

public class QuizDetailsPage : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI quizTitle;
    int currentQuizIndex = 0;

    void OnEnabled() {
        //Grab the most recent created quiz, pdf moment
        currentQuizIndex = QuizzesLoader.Quizzes.QuizList.Count - 1;
        quizTitle.text = QuizzesLoader.Quizzes.QuizList[currentQuizIndex].QuizName;
    }

    public void AddQuestionPressed() {
    }

    public void PreviewQuizPressed() {

    }
}
