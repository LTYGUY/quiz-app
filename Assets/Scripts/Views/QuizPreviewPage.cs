using UnityEngine;
using TMPro;

public class QuizPreviewPage : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI questionNo, question, option1, option2, option3, nextButton;

    [SerializeField] UIOptions options;

    int currentQuestionIndex;
    int ChosenOption => options.ChosenIndex;
    public static int currentScore = 0;

    void OnEnable() {
        this.currentQuestionIndex = 0;
        QuizPreviewPage.currentScore = 0;

        //no quiz was assigned into CurrentQuiz
        if (QuizzesLoader.CurrentQuiz == null)
            return;

        this.SetupQuestion();
        this.nextButton.text = this.currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList.Count - 1 ? "Submit" : "Next";
    }

    public void OnNextButtonPressed() {
        if (this.ChosenOption == -1) return;

        this.IncreaseScoreIfCorrect();

        if (this.currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList.Count - 1) {
            this.OnSubmitButtonPressed();
            return;
        }


        this.currentQuestionIndex++;
        this.options.ChooseOption(-1);
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
        if (ChosenOption != QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].CorrectOptionIndex) return;
        QuizPreviewPage.currentScore++;
    }

    void OnSubmitButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.QuizResultsPage);
    }

    public void OnCancelButtonPressed() {
        MainUI.MoveToPage(MainUIEnum.QuizDetailsPage);
    }
}
