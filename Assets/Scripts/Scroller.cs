using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public Slider scrollSlider;

    // Update is called once per frame
    void Update() {
        transform.localPosition = new Vector2(transform.localPosition.x, scrollSlider.value * 80);
    }
}
