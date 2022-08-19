using UnityEngine;

public class PanelToggler : MonoBehaviour {
    [SerializeField]
    GameObject panel;

    public void TogglePanel() {
        if (this.panel == null) return;
        SetPanelTo(!this.panel.activeSelf);
    }

    public void SetPanelTo(bool a) {
        if (this.panel == null) return;
        this.panel.SetActive(a);
    }
}
