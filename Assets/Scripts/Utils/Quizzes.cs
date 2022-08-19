using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quizzes {
    public List<Quiz> QuizList { get; set; } = new List<Quiz>();
}

public class Quiz {
    public List<Question> QuestionList { get; } = new List<Question>();
}

public readonly struct Question {
    public string QuizQuestion { get; }
    public string[] OptionList { get; }
    public string CorrectOption { get; }

    Question(string quizQuestion, string[] options, string correctOption) {
        this.QuizQuestion = quizQuestion;
        this.OptionList = options;
        this.CorrectOption = correctOption;
    }
}