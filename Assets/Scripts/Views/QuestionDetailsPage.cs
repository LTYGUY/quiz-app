using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class QuestionDetailsPage : MonoBehaviour {

    [SerializeField] UIOptions options;

    [SerializeField] TMP_InputField question;
    [SerializeField] TMP_InputField option1;
    [SerializeField] TMP_InputField option2;
    [SerializeField] TMP_InputField option3;
    int ChosenIndex => options.ChosenIndex;

    public void CorrectOptionChosen(int index) {
        options.ChooseOption(index);
    }
    public void SaveButtonPressed() {
        if (this.ChosenIndex == -1)
            return;

        Question question = new Question(this.question.text, this.ChosenIndex, this.option1.text, this.option2.text, this.option3.text);
        QuizzesLoader.CurrentQuiz.QuestionList.Add(question);
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }
}
