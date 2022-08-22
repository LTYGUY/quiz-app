using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class QuestionDetailsPage : MonoBehaviour {

    [SerializeField] Toggle[] allOptions = new Toggle[3];

    [SerializeField] TMP_InputField question;
    [SerializeField] TMP_InputField option1;
    [SerializeField] TMP_InputField option2;
    [SerializeField] TMP_InputField option3;

    int correctOptionIndex;

    public void CorrectOptionChosen(int index) {
        this.correctOptionIndex = index;

        Debug.Log(correctOptionIndex);
        for (int i = 0; i < this.allOptions.Length; i++) {
            this.allOptions[i].isOn = this.correctOptionIndex == i;
        }
    }
    public void SaveButtonPressed() {
        Question question = new Question(this.question.text, this.correctOptionIndex, this.option1.text, this.option2.text, this.option3.text);
        QuizzesLoader.CurrentQuiz.QuestionList.Add(question);
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }
}
