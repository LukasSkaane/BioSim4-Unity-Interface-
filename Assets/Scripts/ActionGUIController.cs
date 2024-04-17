using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython.Hosting;


public class ActionGUIController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        var enginge = Python.CreateEngine();

        ICollection<string> searchPaths = enginge.GetSearchPaths();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
