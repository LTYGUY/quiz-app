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

    public Dictionary<string, Dictionary<string, Question>> ConvertToJSON() {
        Dictionary<string, Dictionary<string, Question>> quizzesData = new Dictionary<string, Dictionary<string, Question>>();

        for (int i = 0; i < QuizList.Count; i++) {
            Dictionary<string, Question> questionsData = new Dictionary<string, Question>();

            quizzesData.Add(i.ToString(), QuizList[i].ConvertToJSON());
        }

        return quizzesData;
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

    public Dictionary<string, Question> ConvertToJSON() {
        Dictionary<string, Question> questionsData = new Dictionary<string, Question>();

        for (int i = 0; i < QuestionList.Count; i++) {
            Question question = QuestionList[i];
            questionsData.Add(i.ToString(), question);
        }

        return questionsData;
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