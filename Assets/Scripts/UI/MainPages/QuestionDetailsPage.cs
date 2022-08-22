using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDetailsPage : MonoBehaviour {

    [SerializeField]
    Toggle[] allOptions = new Toggle[3];
    int correctOptionIndex;

    public void CorrectOptionChosen(int index) {
        correctOptionIndex = index;

        for (int i = 0; i < allOptions.Length; i++) {
            if (i != correctOptionIndex)
                allOptions[i].isOn = false;
            else
                allOptions[i].isOn = true;
        }
    }
    public void SaveButtonPressed() {

    }
}
