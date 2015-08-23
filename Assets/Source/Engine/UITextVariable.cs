using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextVariable : MonoBehaviour {

    public string variableName;
    public string stringValue;
    public float  numericValue;

	void Start () {
        Text text = GetComponent<Text>();
        text.text = text.text.Replace("#{" + variableName + "}", string.IsNullOrEmpty(stringValue) ? numericValue.ToString() : stringValue);
	}
}
