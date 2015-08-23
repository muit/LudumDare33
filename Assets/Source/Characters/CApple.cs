using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CApple : Character {
    private NavMeshAgent agent;
    private AIRangeDetection detection;

    public int minDrop = 0;
    public int maxDrop = 3;

    protected override void OnGameStart(SceneScript scene)
    {
        agent = GetComponent<NavMeshAgent>();

        detection = GetComponentInChildren<AIRangeDetection>();
        detection.Load(this);
    }

    void Update()
    {
        if (!isAlive) return;

        if (!isInCombat)
        {
            //Find next enemy
            if (detection.haveEnemies)
            {
                StartCombat(detection.GetNextEnemy());
            }
            return;
        }


        //Combat AI

        if((target.transform.position - agent.destination).sqrMagnitude > 1)
        {
            agent.SetDestination(target.transform.position);
        }

        if (Vector3.Distance(target.transform.position, transform.position) < agent.stoppingDistance+1)
        {
            Kill();
        }
    }

    protected override void JustDied(Character killer)
    {
        agent.Stop();
        if (killer)
        {
            Explosion.CreateSmall(transform.position);
            Coin.Drop(transform.position, minDrop, maxDrop);
        }
        else
        {
            Explosion.Create(transform.position);
            ((Main)Main.Instance).LooseLive();
        }
    }


}
