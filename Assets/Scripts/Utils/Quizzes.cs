using System;
using System.Collections.Generic;

[Serializable]
public class Quizzes {
    public long Timestamp { get; set; } = 0;
    public List<Quiz> QuizList { get; set; } = new List<Quiz>();

    public Quizzes(List<Quiz> quizList) {
        this.QuizList = quizList;
        this.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}

[Serializable]
public class Quiz {
    public string QuizName { get; set; }
    public List<Question> QuestionList { get; set; } = new List<Question>();

    public Quiz(string quizName, List<Question> questionList) {
        this.QuizName = quizName;
        this.QuestionList.AddRange(questionList);
    }
}

[Serializable]
public class Question {
    public string Query { get; set; }
    public int AnswerIndex { get; set; }
    public string[] OptionList { get; set; }

    public Question(string quizQuestion, int correctOption, params string[] options) {
        this.Query = quizQuestion;
        this.AnswerIndex = correctOption;
        this.OptionList = options;
    }
}