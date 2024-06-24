using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideGUI : MonoBehaviour {
    bool hidden = true, shouldMove = false;
    float distance = Screen.width / 3, newPosition;
    public GameObject outerButton;

    // Update is called once per frame
    void Update() {
        if (shouldMove) {
            moveTowardsX(gameObject);
            if (gameObject.transform.position.x == newPosition) {
                outerButton.SetActive(hidden);
                shouldMove = !shouldMove;
            }
        }
    }

    void moveTowardsX(GameObject objToMove) {
        objToMove.transform.position = Vector2.MoveTowards(objToMove.transform.position, new Vector2(newPosition, objToMove.transform.position.y), 3);
    }
}
