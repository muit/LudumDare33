using UnityEngine;
using System.Collections;

public class CPlayer : Character {
    public float rotateSpeed = 1;
    public LayerMask floorLayer;

    private Rigidbody rigidbody;

	protected override void OnGameStart(SceneScript scene) {
        rigidbody = GetComponent<Rigidbody>();
        team = Team.CUCUMBIS;
	}
	
	void Update () {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Rotate();

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
	}

    private void Move(float h,float v) {
        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            Vector3 velocity = rigidbody.velocity;
            velocity.x = 0;
            velocity.z = 0;
            velocity += new Vector3(h, 0, v) * speed * speedModifier;

            rigidbody.velocity = velocity;
        }
    }

    private void Rotate() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 200f, floorLayer))
        {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0;

            Quaternion dirQ = Quaternion.LookRotation(direction);

            rigidbody.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
        }
    }
}
