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

    public static QuestionDetailsPage QuestionDetailsPage;

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

        MainUI.QuestionDetailsPage = questionDetailsPage.GetComponent<QuestionDetailsPage>();
    }

    public static void MoveToPage(MainUIEnum page) {
        if (MainUI.currentPage) MainUI.currentPage.SetActive(false);

        MainUI.currentPage = MainUI.mainPages[(int)page];
        MainUI.currentPage.SetActive(true);
    }
}

