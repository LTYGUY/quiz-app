using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class QuestionDetailsPage : MonoBehaviour {

    [SerializeField]
    Toggle[] allOptions = new Toggle[3];
    int correctOptionIndex;

    [SerializeField]
    TMP_InputField question, option1, option2, option3;

    public void CorrectOptionChosen(int index) {
        correctOptionIndex = index;

        Debug.Log(correctOptionIndex);
        for (int i = 0; i < allOptions.Length; i++) {
            if (i != correctOptionIndex)
                allOptions[i].isOn = false;
            else
                allOptions[i].isOn = true;
        }
    }
    public void SaveButtonPressed() {
        QuizzesLoader.CurrentQuiz.QuestionList.Add(new Question(question.text, correctOptionIndex, option1.text, option2.text, option3.text));
        MainUIs.MoveToPage(MainUIsEnum.QuizDetailsPage);
    }
}
