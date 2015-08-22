using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public CPlayer motion;

    public float distance = 10;
    public float inclination = 45;
    public float yRotation = 180;
    public float moveDamping = 2;
    public float lookDamping = 2;
    public float teleportAtDistance = 100;

	void LateUpdate () {
        if (motion != null) {
            UpdatePosition(motion.transform);
        }
        else if(SceneScript.Instance.spawn){
            UpdatePosition(SceneScript.Instance.spawn.transform);
        }
    }

    public void SetTarget(CPlayer _motion)
    {
        motion = _motion;
    }

    private void UpdatePosition(Transform trans)
    {
        if (!trans)
        {
            Debug.LogWarning("Camera target transform is null.");
            return;
        }

        Vector3 position = trans.position;
        position.y += distance * Mathf.Sin((90 - inclination) * 2 * Mathf.PI / 360);
        float catet = distance * Mathf.Cos((90 - inclination) * 2 * Mathf.PI / 360);

        position.x += catet * Mathf.Cos(yRotation * 2 * Mathf.PI / 360);
        position.z += catet * Mathf.Sin(yRotation * 2 * Mathf.PI / 360);

        //Smooth LookAt
        Quaternion targetRotation = Quaternion.LookRotation(trans.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookDamping * Time.deltaTime);

        //Temporal fix camera stutting
        transform.position = position;

        /*
        //Teleport camera if is too far
        if (Vector3.Distance(trans.position, transform.position) > teleportAtDistance)
            transform.position = position;
        else
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * moveDamping);
        */
    }
}
