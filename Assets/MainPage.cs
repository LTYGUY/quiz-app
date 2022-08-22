using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour {
    [SerializeField]
    Transform quizPrefab;
    [SerializeField]
    Transform quizzesContainer;
    void Awake() {
        QuizzesLoader.OnQuizzesLoad += OnQuizzesLoad;
        QuizzesLoader.OnNewQuizAdded += AddNewQuiz;
    }

    void OnQuizzesLoad() {
        foreach (Quiz quiz in QuizzesLoader.Quizzes.QuizList) {
            AddNewQuiz(quiz);
        }
    }

    void AddNewQuiz(Quiz quiz) {
        Instantiate(quizPrefab, quizzesContainer);
    }

    public void OnCreateQuizButtonPressed() {
        MainUIs.MoveToPage(MainUIsEnum.NewQuizPage);
    }
}
