using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour {
    public void OnCreateQuizButtonPressed() {
        MainUIs.MoveToPage(MainUIsEnum.NewQuizPage);
    }
}
