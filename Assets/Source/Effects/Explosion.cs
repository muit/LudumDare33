using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public float destroyDelay = 1;

	void Start () {
        Destroy(gameObject, destroyDelay);
	}

    public static void Create(Vector3 position)
    {
        Instantiate(Cache.Get.explosion, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
    }
}
