using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIs : MonoBehaviour {
    [SerializeField]
    GameObject mainPage, newQuizPage, quizDetailsPage, questionDetailsPage, quizPreviewPage, quizResultsPage;

    static GameObject currentPage;
    static GameObject[] mainPages;

    void Awake() {
        mainPages = new GameObject[] { mainPage, newQuizPage, quizDetailsPage, questionDetailsPage, quizPreviewPage, quizResultsPage };
        foreach (GameObject o in mainPages) {
            o.SetActive(false);
        }

        MoveToPage(MainUIsEnum.MainPage);
    }

    public static void MoveToPage(MainUIsEnum page) {
        if (currentPage)
            currentPage.SetActive(false);

        currentPage = mainPages[(int)page];
        currentPage.SetActive(true);
    }
}

public enum MainUIsEnum {
    MainPage,
    NewQuizPage,
    QuizDetailsPage,
    QuestionDetailsPage,
    QuizPreviewPage,
    QuizResultsPage
};
