using UnityEngine;
using System.Collections;

public class SphereExploder : Exploder {
	public override IEnumerator explode() 
	{
		exploded = true;
		
		ExploderComponent[] components = GetComponents<ExploderComponent>();
		foreach (ExploderComponent component in components) {
			component.onExplosionStarted(this);
		}


		while (explodeDuration > Time.time - explosionTime) {
			collider.isTrigger = true;
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders) {
                if (hit.GetComponent<Item>())
                {
                    Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
                    if (hit && rigidbody)
                    {
                        rigidbody.AddExplosionForce(power * Time.deltaTime, explosionPos, radius);
                    }
                }
			}
			//collider.isTrigger = false;
			yield return new WaitForEndOfFrame();
		}
	}

	void Start() {
        collider = GetComponent<Collider>();

		power *= 200;
		
		if (randomizeExplosionTime > 0.01f) {
			explosionTime += Random.Range(0.0f, randomizeExplosionTime);
		}
	}

	void FixedUpdate () {
		if (Time.time > explosionTime && !exploded) {
			StartCoroutine("explode");
		}
	}
}
