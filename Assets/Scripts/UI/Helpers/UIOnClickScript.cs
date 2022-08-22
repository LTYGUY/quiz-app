using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[System.Serializable]
public class MyEvent : UnityEvent {
}

public class UIOnClickScript : MonoBehaviour, IPointerClickHandler {
    public MyEvent onClick;

    public void OnPointerClick(PointerEventData data) {
        onClick?.Invoke();
    }
}
