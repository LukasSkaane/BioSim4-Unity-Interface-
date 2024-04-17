using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ViewGUIController : MonoBehaviour
{
    public string configFilepath = "C:\\Users\\lukas\\OneDrive\\Desktop\\Programming\\C++\\Evolutionary System - David R Miller\\biosim4\\tests\\configs\\";
    public string configFileName = "quicktest.ini";
    private List<string> fileName;
    private List<string> parameterSetting;
    public GameObject maskingNode;
    public TMP_InputField prefabInputField;
    public GameObject textBackground;
    UITools uiTool;

    string line;
    int currentTextPosY = 162;
    // Start is called before the first frame update
    void Start() {
        uiTool = new UITools(maskingNode, prefabInputField);

        fileName = new List<string>();
        var info = new DirectoryInfo("Assets/Resources/Movies");
        FileInfo[] fileInfo = info.GetFiles();
        foreach (var file in fileInfo ) {
            if (file.Name.EndsWith(".avi"))
                fileName.Add(file.Name);
        }

        

        for (int i = 0; i < fileName.Count; i++) {
            GameObject newParam = uiTool.createParameterUIElement(fileName[i]);
            currentTextPosY -= 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
