using UnityEngine;
using System.Collections;

public class Character : Object {
    public Team team = Team.FRUITS;

    //Combat
    protected Character target;

    public bool isInCombat {
        get { return target != null; }
    }

    public void StartCombat(Character unit) {
        target = unit;
    }

    private void Fire()
    {

    }


    //Health
    public int health {
        private set {
            this.health = (value > 0) ? value : 0;
        }
        get { return this.health; }
    }

    public void Damage(Character unit, int amount)
    {
        if (isAlive)
        {
            health -= amount;
            OnDamage(unit, amount);
            if (!isAlive)
            {
                JustDied(unit);
            }
        }
    }

    public bool isAlive {
        get { return health > 0; }
    }


    //Events
    protected virtual void OnDamage(Character unit, int amount) { }
    protected virtual void JustDied(Character killer) { }
    //protected virtual void OnCombatEnter(Character unit) { }
    //protected virtual void OnCombatExit() { }
}
