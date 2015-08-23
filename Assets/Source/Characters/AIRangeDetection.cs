using UnityEngine;
using System.Collections.Generic;

public class AIRangeDetection : MonoBehaviour {
    public float range = 5;
    public bool haveEnemies {
        get { return nearEnemies.Count > 0; }
    }

    Character me;
    List<Character> nearEnemies = new List<Character>();

    void Start() {
        SphereCollider trigger = GetComponent<SphereCollider>();
        float radiusScale = (transform.lossyScale.x + transform.lossyScale.y + transform.lossyScale.z) / 3;
        trigger.radius = range * radiusScale;
    }

    public void Load(Character me) {
        this.me = me;
    }

    public Character GetNextEnemy() {
        return nearEnemies.Find(x => x != me.target);
    }

    void OnTriggerEnter(Collider col)
    {
        Character unit = col.GetComponent<CPlayer>();
        if (unit && unit.team != me.team)
        {
            nearEnemies.Add(unit);
        }
    }

    void OnTriggerExit(Collider col)
    {
        Character unit = col.GetComponent<CPlayer>();
        if (unit)
        {
            nearEnemies.Remove(unit);
        }
    }
}
