using System.Collections.Generic;

public class Quiz {
    public List<Question> QuestionList { get; } = new List<Question>();

    public Quiz(List<Question> questionList) {
        this.QuestionList.AddRange(questionList);
    }
}

public readonly struct Question {
    public string QuizQuestion { get; }
    public string[] OptionList { get; }
    public string CorrectOption { get; }

    public Question(string quizQuestion, string correctOption, params string[] options) {
        this.QuizQuestion = quizQuestion;
        this.OptionList = options;
        this.CorrectOption = correctOption;
    }
}