using UnityEngine;
using System.Collections;

public class DestroyAfterSecs : MonoBehaviour {

    public float seconds = 1;

	void Start () {
        Destroy(gameObject, seconds);
	}
}
