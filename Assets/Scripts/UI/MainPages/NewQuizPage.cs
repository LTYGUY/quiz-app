using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewQuizPage : MonoBehaviour {
    [SerializeField]
    TMP_InputField quizName;

    public void SaveButtonPressed() {
        //Do something
        QuizzesLoader.AddNewQuiz(new Quiz(quizName.text, new List<Question>()));
    }
}
