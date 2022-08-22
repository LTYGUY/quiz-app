using UnityEngine;
using TMPro;

public class QuizPreviewPage : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI questionNo, question, option1, option2, option3, nextButton;

    int currentQuestionIndex;
    int chosenOption = -1;
    public static int currentScore = 0;

    void OnEnable() {
        this.currentQuestionIndex = 0;
        QuizPreviewPage.currentScore = 0;
        this.SetupQuestion();
        this.nextButton.text = this.currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList.Count - 1 ? "Submit" : "Next";
    }

    public void ChooseOption(int index) {
        this.chosenOption = index;
    }

    public void OnNextButtonPressed() {
        if (this.chosenOption == -1) return;

        if (this.currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList.Count - 1) {
            this.OnSubmitButtonPressed();
            return;
        }

        this.IncreaseScoreIfCorrect();
        this.currentQuestionIndex++;
        this.chosenOption = -1;
        this.SetupQuestion();

        if (currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList.Count - 1) {
            nextButton.text = "Submit";
        }
    }

    void SetupQuestion() {
        questionNo.text = $"Question ({currentQuestionIndex + 1}/{QuizzesLoader.CurrentQuiz.QuestionList.Count})";
        question.text = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].QuizQuestion;
        option1.text = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].OptionList[0];
        option2.text = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].OptionList[1];
        option3.text = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].OptionList[2];
    }

    void IncreaseScoreIfCorrect() {
        if (currentQuestionIndex != QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].CorrectOptionIndex) return;
        QuizPreviewPage.currentScore++;
    }

    void OnSubmitButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.QuizResultsPage);
    }
}
