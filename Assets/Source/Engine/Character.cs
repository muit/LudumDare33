using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

[RequireComponent(typeof(PlatformerCharacter2D))]

public class Character : MonoBehaviour {

	void Start () {
        OnGameStart(SceneScript.Instance);
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
        if (IsAlive())
        {
            health -= amount;
            OnDamage(unit, amount);
            if (!IsAlive())
            {
                JustDied(unit);
            }
        }
    }

    public bool IsAlive() {
        return health > 0;
    }


    //Events
    protected virtual void OnGameStart(SceneScript scene) { }
    protected virtual void OnDamage(Character unit, int amount) { }
    protected virtual void JustDied(Character killer) { }
    //protected virtual void OnCombatEnter(Character unit) { }
    //protected virtual void OnCombatExit() { }
}
