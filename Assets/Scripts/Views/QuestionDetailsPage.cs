using UnityEngine;
using TMPro;

public class QuestionDetailsPage : MonoBehaviour {

    [SerializeField] UIOptions options;

    [SerializeField] TMP_InputField question;
    [SerializeField] TMP_InputField option1;
    [SerializeField] TMP_InputField option2;
    [SerializeField] TMP_InputField option3;
    int ChosenIndex => options.ChosenIndex;

    int currentQuestionIndex;

    public void CorrectOptionChosen(int index) {
        options.ChooseOption(index);
    }

    //-1 is create new question
    public void OnEditQuestion(int questionIndex) {
        currentQuestionIndex = questionIndex;
        if (currentQuestionIndex == -1)
            return;

        Question question = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex];
        this.question.text = question.Query;
        this.option1.text = question.OptionList[0];
        this.option2.text = question.OptionList[1];
        this.option3.text = question.OptionList[2];
        this.options.ChooseOption(question.AnswerIndex);
    }

    public void OnSaveButtonPressed() {
        if (this.ChosenIndex == -1)
            return;

        if (currentQuestionIndex != -1) {
            QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex] = new Question(this.question.text, this.ChosenIndex, this.option1.text, this.option2.text, this.option3.text);
        }
        else {
            Question question = new Question(this.question.text, this.ChosenIndex, this.option1.text, this.option2.text, this.option3.text);
            QuizzesLoader.CurrentQuiz.QuestionList.Add(question);
        }

        QuizzesLoader.SaveQuizzes();
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }

    public void OnCancelButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }
}
