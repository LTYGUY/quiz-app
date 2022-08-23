using UnityEngine;
using TMPro;

public class Main_QuizPrefab : MonoBehaviour {
    [SerializeField] TextMeshProUGUI index;
    [SerializeField] TextMeshProUGUI quizName;

    public void Setup(string _index, string _quizName) {
        index.text = _index;
        quizName.text = _quizName;
    }
}
