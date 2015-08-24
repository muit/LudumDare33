using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class COrange : Character {
    private NavMeshAgent agent;
    private AIRangeDetection detection;
    private AISlowArea slowArea;

    public int minDrop = 0;
    public int maxDrop = 3;

    protected override void OnGameStart(SceneScript scene)
    {
        agent = GetComponent<NavMeshAgent>();

        detection = GetComponentInChildren<AIRangeDetection>();
        detection.Load(this);

        slowArea = GetComponentInChildren<AISlowArea>();
        slowArea.Load(this);
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
    }

    protected override void JustDied(Character killer)
    {
        agent.Stop();

        Explosion.CreateSmall(transform.position);
        Coin.Drop(transform.position, minDrop, maxDrop);
    }


}
