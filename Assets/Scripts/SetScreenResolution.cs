using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Screen.SetResolution(640, 480, true);
    }

}
