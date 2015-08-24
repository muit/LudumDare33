﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class UIObject : MonoBehaviour
{
    public UnityEvent onStart;
    public bool disableOnComplete = false;
    public float disableDelay = 2.0f;
    [Space(20)]
    public int[] completeOnMouseClick;
    public string[] completeOnKeys;
    public string[] completeOnAxis;
    public CompleteEvent onComplete;
    
    [System.NonSerialized]
    public bool completed = false;

    void Start() {
        onStart.Invoke();
    }

    void Update () {
        if (!completed)
        {
            for (int i = 0; i < completeOnMouseClick.Length; i++)
            {
                if (Input.GetMouseButton(completeOnMouseClick[i]))
                {
                    StartCoroutine(Complete(disableDelay));
                    return;
                }
            }

            for (int i = 0; i < completeOnKeys.Length; i++)
            {
                if (Input.GetKey(completeOnKeys[i]))
                {
                    StartCoroutine(Complete(disableDelay));
                    return;
                }
            }

            for (int e = 0; e < completeOnAxis.Length; e += 1)
            {
                float value = Input.GetAxis(completeOnAxis[e]);
                if (value > 0.1f || value < -0.1f)
                {
                    StartCoroutine(Complete(disableDelay));
                    return;
                }
            }
        }
  }

    IEnumerator Complete(float delay)
    {
        if (!completed)
            completed = true;
        yield return new WaitForSeconds(delay);

        onComplete.Invoke();
        if (disableOnComplete)
            gameObject.SetActive(false);
    }

    [System.Serializable]
    public class CompleteEvent : UnityEvent { };
}
