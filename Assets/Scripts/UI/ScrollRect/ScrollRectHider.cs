using UnityEngine;
using UnityEngine.UI;

public class ScrollRectHider : MonoBehaviour {
    [SerializeField]
    Image[] imagesToHide;

    [SerializeField]
    RectTransform scrollRect;

    [SerializeField]
    RectTransform scrollRectContent;

    void OnGUI() {
        if (!gameObject.activeInHierarchy) return;
        this.UpdateScrollRect();
    }

    void UpdateScrollRect() {
        foreach (Image image in this.imagesToHide) {
            image.enabled = this.scrollRectContent.rect.height > this.scrollRect.rect.height;
        }
    }
}
