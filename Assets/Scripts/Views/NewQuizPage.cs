using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewQuizPage : MonoBehaviour {
    [SerializeField]
    TMP_InputField quizName;

    public void OnSaveButtonPressed() {
        //Do something
        QuizzesLoader.AddNewQuiz(new Quiz(this.quizName.text, new List<Question>()));
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }

    public void OnCancelButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.MainPage);
    }
}
