using System;
using System.Collections.Generic;

[Serializable]
public class Quizzes {
    public List<Quiz> QuizList { get; } = new List<Quiz>();
    public long Timestamp { get; } = 0;

    public Quizzes(List<Quiz> quizList) {
        this.QuizList = quizList;
        this.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}

[Serializable]
public class Quiz {
    public string QuizName { get; }
    public List<Question> QuestionList { get; } = new List<Question>();

    public Quiz(string quizName, List<Question> questionList) {
        this.QuizName = quizName;
        this.QuestionList.AddRange(questionList);
    }
}

[Serializable]
public class Question {
    public string QuizQuestion { get; }
    public int CorrectOptionIndex { get; }
    public string[] OptionList { get; }

    public Question(string quizQuestion, int correctOption, params string[] options) {
        this.QuizQuestion = quizQuestion;
        this.OptionList = options;
        this.CorrectOptionIndex = correctOption;
    }
}