using UnityEngine;
using System.Collections;

public class Character : Item {
    public Team team = Team.FRUITS;
    public float despawnTime = 1500;

    //Combat
    public Character target {
        get;
        protected set;
    }

    protected ObjectPool bulletPool = new ObjectPool(30);

    public bool isInCombat {
        get { return target != null; }
    }

    public void StartCombat(Character unit) {
        target = unit;
        OnCombatEnter(unit);
    }

    protected void Fire()
    {
        Bullet bullet = bulletPool.Create(Cache.Get.bullet, transform.position) as Bullet;
        bullet.Shoot(this, transform.forward);
    }


    //Health
    [SerializeField]
    private int _health = 0;

    public int health {
        private set {
            _health = (value > 0) ? value : 0;
        }
        get { return _health; }
    }

    public bool isAlive
    {
        get { return _health > 0; }
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

    public void Kill(Character killer = null) {
        if (isAlive)
        {
            target = null;
            health = 0;
            JustDied(killer);
            Despawn(despawnTime);
        }
    }

    public void Despawn(float delay = 2)
    {
        GameObject.Destroy(gameObject, delay);
    }


    //Events
    protected virtual void OnDamage(Character unit, int amount) { }
    protected virtual void JustDied(Character killer) { }
    protected virtual void OnCombatEnter(Character target) { }
    //protected virtual void OnCombatExit() { }
}
