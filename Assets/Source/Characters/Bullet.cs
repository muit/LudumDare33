using UnityEngine;
using System.Collections;

public class Bullet : Item {
    public float despawnDistance = 50;
    public float speed = 3.0f;
    [System.NonSerialized]
    public Vector3 direction;

    private bool shooted = false;
    private Vector3 startPosition;

    protected override void OnGameStart(SceneScript scene) {
        startPosition = transform.position;
    }

    public void Shoot() {
        shooted = true;
    }

	void Update ()
    {
        if((startPosition - transform.position).sqrMagnitude > despawnDistance * despawnDistance){
            gameObject.SetActive(false);
            return;
        }

        if (shooted)
        {
            transform.position += direction * speed;
        }
	}
}
