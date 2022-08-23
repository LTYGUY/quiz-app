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
    public string Query { get; }
    public int CorrectOptionIndex { get; set; }
    public string[] OptionList { get; set; }

    public Question(string quizQuestion, int correctOption, params string[] options) {
        this.Query = quizQuestion;
        this.CorrectOptionIndex = correctOption;
        this.OptionList = options;
    }
}