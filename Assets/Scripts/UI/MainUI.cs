using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour {
    [SerializeField] GameObject mainPage;
    [SerializeField] GameObject newQuizPage;
    [SerializeField] GameObject quizDetailsPage;
    [SerializeField] GameObject questionDetailsPage;
    [SerializeField] GameObject quizPreviewPage;
    [SerializeField] GameObject quizResultsPage;

    static GameObject currentPage;
    static List<GameObject> mainPages;

    void Awake() {
        MainUI.mainPages = new List<GameObject>() {
            mainPage,
            newQuizPage,
            quizDetailsPage,
            questionDetailsPage,
            quizPreviewPage,
            quizResultsPage
        };

        MainUI.mainPages.ForEach(go => go.SetActive(false));
        MainUI.MoveToPage(MainUIEnum.MainPage);
    }

    public static void MoveToPage(MainUIEnum page) {
        MainUI.currentPage.SetActive(!currentPage);
        MainUI.currentPage = MainUI.mainPages[(int)page];
        MainUI.currentPage.SetActive(true);
    }
}

