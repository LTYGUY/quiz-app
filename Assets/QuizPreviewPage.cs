using UnityEngine;
using TMPro;

public class QuizPreviewPage : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI questionNo, question, option1, option2, option3, nextButton;

    int currentQuestionIndex;
    int chosenOption = -1;
    public static int currentScore = 0;

    void OnEnable() {
        currentQuestionIndex = 0;
        currentScore = 0;

        SetupQuestion();

        if (currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList.Count - 1)
            nextButton.text = "Submit";
        else
            nextButton.text = "Next";
    }

    public void ChooseOption(int index) {
        chosenOption = index;
    }

    public void OnNextButtonPressed() {
        if (chosenOption == -1) {
            return;
        }

        if (currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList.Count - 1) {
            OnSubmitButtonPressed();
            return;
        }

        IncreaseScoreIfCorrect();
        currentQuestionIndex++;

        chosenOption = -1;

        SetupQuestion();

        if (currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList.Count - 1)
            nextButton.text = "Submit";
    }

    void SetupQuestion() {
        questionNo.text = $"Question ({currentQuestionIndex + 1}/{QuizzesLoader.CurrentQuiz.QuestionList.Count})";
        question.text = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].QuizQuestion;
        option1.text = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].OptionList[0];
        option2.text = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].OptionList[1];
        option3.text = QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].OptionList[2];
    }

    void IncreaseScoreIfCorrect() {
        if (currentQuestionIndex == QuizzesLoader.CurrentQuiz.QuestionList[currentQuestionIndex].CorrectOptionIndex)
            currentScore++;
    }

    void OnSubmitButtonPressed() {

        MainUIs.MoveToPage(MainUIsEnum.QuizResultsPage);
    }
}
