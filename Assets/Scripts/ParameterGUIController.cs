using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class UITools : MonoBehaviour {
    public UITools(GameObject maskingNode, TMP_InputField prefabInputField) {
        this.maskingNode = maskingNode;
        this.prefabInputField = prefabInputField;
    }

    public GameObject maskingNode;
    public TMP_InputField prefabInputField;
    int currentTextPosY = 162;

    public GameObject createParameterUIElement(string str, string? value = null) {
        GameObject newParam = new GameObject(str);
        TextMeshProUGUI text = newParam.AddComponent<TextMeshProUGUI>();
        RectTransform textRect = text.GetComponent<RectTransform>();
        newParam.transform.SetParent(maskingNode.transform);
        newParam.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        newParam.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-5, currentTextPosY, 0);
        textRect.sizeDelta = new Vector2(textRect.sizeDelta.x * 2f, textRect.sizeDelta.y * .8f);

        text.alignment = TextAlignmentOptions.MidlineLeft;
        text.text = str;
        text.fontSize = 24;
        text.overflowMode = TextOverflowModes.Masking;

        if (value != null)
            createParameterModifier(value);

        currentTextPosY -= 20;
        return newParam;
    }

    void createParameterModifier(string value) {
        TMP_InputField inputField = Instantiate<TMP_InputField>(prefabInputField, maskingNode.transform);
        inputField.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(inputField.transform.localPosition.x, currentTextPosY, 0);
        inputField.text = value;
        inputField.textComponent.color = Color.white;
    }
}

public class ParameterGUIController : MonoBehaviour {

    public string configFilepath = "C:\\Users\\lukas\\OneDrive\\Desktop\\Programming\\C++\\Evolutionary System - David R Miller\\biosim4\\tests\\configs\\";
    public string configFileName = "quicktest.ini";
    private List<string> parameterNames;
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

        parameterNames = new List<string>();
        parameterSetting = new List<string>();
        readConfigFile();

        for (int i = 0; i < parameterNames.Count; i++) {
            var textBG = Instantiate(textBackground, maskingNode.transform);
            GameObject newParam = uiTool.createParameterUIElement(parameterNames[i], parameterSetting[i]);
            textBG.transform.position = newParam.transform.position;
        }

    }

    // Update is called once per frame
    void Update() {

    }

    void readConfigFile() {
        StreamReader sr = new StreamReader(configFilepath + configFileName);
        do {
            line = sr.ReadLine();
            if (!line.Contains("[") && line.Length > 1) {
                string pName = line.Split(" ")[0];
                parameterSetting.Add(line.Substring(pName.Length + 2));
                if (pName.Contains("param-"))
                    pName = pName.Replace("param-", "");
                if (pName.Contains("result-"))
                    pName = pName.Replace("result-", "");
                parameterNames.Add(pName);

            }
        } while (line != " ");
        sr.Close();
    }

    void saveConfigFile() {
        var iniFile = new SavingFunction.IniFile(configFilepath + configFileName);
    }


    void setDefaultTextSettings(ref TextMeshPro text) {

    }
}

