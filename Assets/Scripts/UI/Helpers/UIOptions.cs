using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour {
    [SerializeField] Transform checkmarkPrefab;
    //Please setup this by assigning where you want the checkmark to spawn into.
    [SerializeField] Transform[] checkmarkContainers = new Transform[3];

    public int ChosenIndex { get; private set; } = -1;
    GameObject spawnedCheckMark;

    public void ChooseOption(int index) {
        ChosenIndex = index;

        if (spawnedCheckMark)
            Destroy(spawnedCheckMark);

        if (ChosenIndex == -1)
            return;

        Transform cloned = Instantiate(checkmarkPrefab, checkmarkContainers[ChosenIndex]);
        spawnedCheckMark = cloned.gameObject;
    }

    void OnEnable() {
        ChooseOption(-1);
    }
}
