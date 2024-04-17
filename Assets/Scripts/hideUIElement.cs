using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hideUIElement : MonoBehaviour {
    public GameObject guiElement;
    float originalPosX, distance, outOfScreenPos;
    bool hide;

    private void Start() {
        hide = false;
        originalPosX = guiElement.transform.position.x;
        distance = Screen.width / 3;
        gameObject.GetComponent<Button>().onClick.AddListener(move);
    }

    public void move() {
        distance = guiElement.transform.parent.transform.parent.transform.localScale.x;
        Debug.Log(distance);
        outOfScreenPos = originalPosX - distance;
        hide = !hide;
    }

    private void Update() {
        if (hide) { guiElement.transform.position = Vector2.MoveTowards(guiElement.transform.position, new Vector2(outOfScreenPos, guiElement.transform.position.y), 5);        }
        if (guiElement.transform.position.x == outOfScreenPos) hide = false;
    }
}
