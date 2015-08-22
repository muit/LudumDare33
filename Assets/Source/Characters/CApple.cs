using UnityEngine;
using System.Collections.Generic;

public class CApple : Character {
    private NavMeshAgent agent;

    public float detectionDistance = 1;

    public int minDrop = 0;
    public int maxDrop = 3;

    protected override void OnGameStart(SceneScript scene)
    {
        agent = GetComponent<NavMeshAgent>();
        
        SphereCollider[] distanceTriggers = GetComponents<SphereCollider>();
        foreach (SphereCollider trigger in distanceTriggers)
        {
            if (trigger.isTrigger)
            {
                float radiusScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z)/3;
                trigger.radius = detectionDistance / radiusScale;
            }
        }
    }

    void Update()
    {
        if (isInCombat)
        {
            agent.SetDestination(target.transform.position);
        }
        else
        {
            if (nearEnemyCharacters.Count > 0)
            {
                StartCombat(nearEnemyCharacters.Find(x => x != target));
            }
        }
    }

    protected override void JustDied(Character killer)
    {
        Coin.Drop(transform.position, minDrop, maxDrop);
    }




    //Near Enemies
    List<Character> nearEnemyCharacters = new List<Character>();

    void OnTriggerEnter(Collider col)
    {
        Character unit = col.GetComponent<CPlayer>();
        if (unit && unit.team != team) {
            nearEnemyCharacters.Add(unit);
        }
    }

    void OnTriggerExit(Collider col)
    {
        Character unit = col.GetComponent<CPlayer>();
        if (unit)
        {
            nearEnemyCharacters.Remove(unit);
        }
    }
}
