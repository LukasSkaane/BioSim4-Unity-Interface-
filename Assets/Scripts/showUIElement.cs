using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showUIElement : MonoBehaviour
{
    public GameObject guiElement;
    float originalPosX, distance, outOfScreenPos;
    bool hide;

    private void Start() {
        hide = false;
        originalPosX = guiElement.transform.position.x;
        distance = Screen.width / 3;
        gameObject.GetComponent<Button>().onClick.AddListener(move);
    }

    void move() {
        outOfScreenPos = originalPosX - distance;
        hide = !hide;
    }

    private void Update() {
        if (guiElement.transform.position.x == outOfScreenPos) hide = false;
    }
}
