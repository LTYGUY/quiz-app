using UnityEngine;
using TMPro;

public class QuizDetailsPrefab : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI index, question;

    public void Setup(string _index, string _question) {
        index.text = _index;
        question.text = _question;
    }
}
