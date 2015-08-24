using UnityEngine;
using System.Collections.Generic;

public class AISlowArea : MonoBehaviour {
    public float speedModifier = 0.5f;
    public bool haveEnemies
    {
        get { return nearEnemies.Count > 0; }
    }

    Character me;
    List<Character> nearEnemies = new List<Character>();

    void Start()
    {
        SphereCollider trigger = GetComponent<SphereCollider>();
    }

    public void Load(Character me)
    {
        this.me = me;
    }

    public Character GetNextEnemy()
    {
        return nearEnemies.Find(x => x != me.target);
    }

    void OnTriggerEnter(Collider col)
    {
        Character unit = col.GetComponent<CPlayer>();
        if (unit && unit.team != me.team)
        {
            nearEnemies.Add(unit);
            unit.SetSpeedModifier(speedModifier);
        }
    }

    void OnTriggerExit(Collider col)
    {
        Character unit = col.GetComponent<CPlayer>();
        if (unit)
        {
            nearEnemies.Remove(unit);
            unit.SetSpeedModifier(1);
        }
    }

    void OnDestroy()
    {
        for (int i = 0; i < nearEnemies.Count; i++)
            nearEnemies[i].SetSpeedModifier(1);
    }
}
