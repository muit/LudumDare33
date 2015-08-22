using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {

    void Start()
    {
        OnGameStart(SceneScript.Instance);
    }

    //Events
    protected virtual void OnGameStart(SceneScript scene) { }
}
