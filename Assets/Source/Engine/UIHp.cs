using UnityEngine;
using System.Collections;

public class UIHp : MonoBehaviour {
    public void Show(bool value) {
        gameObject.SetActive(value);
    }
}
