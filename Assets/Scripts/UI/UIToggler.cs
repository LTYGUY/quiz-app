using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggler : MonoBehaviour
{
    public GameObject ui;                       // To get the panel

    public void TogglePanel()
    {
        if (ui == null)
        {
            return;
        }

        bool isActive = ui.activeSelf;

        SetPanelTo(!isActive);
    }

    public void SetPanelTo(bool a)
    {
        if (ui == null)
        {
            return;
        }
        ui.SetActive(a);
    }
}
