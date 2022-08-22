using UnityEngine;
using TMPro;

public class QuizDetailsPrefab : MonoBehaviour {
    [SerializeField] TextMeshProUGUI index;
    [SerializeField] TextMeshProUGUI question;

    public void Setup(string index, string question) {
        this.index.text = index;
        this.question.text = question;
    }
}
