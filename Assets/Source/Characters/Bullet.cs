using UnityEngine;
using System.Collections;

public class Bullet : Item {
    public float despawnDistance = 50;
    public float speed = 5.0f;
    [System.NonSerialized]
    public Vector3 direction;

    private Character caster;
    private bool shooted = false;
    private Vector3 startPosition;
    private Rigidbody rigidbody;

    protected override void OnGameStart(SceneScript scene)
    {
        rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    public void Shoot(Character caster, Vector3 direction)
    {
        if(!rigidbody) rigidbody = GetComponent<Rigidbody>();

        if(shooted) return;

        shooted = true;
        this.direction = direction;
        this.caster = caster;

        rigidbody.velocity = direction * speed;
        transform.LookAt(transform.position + direction);

        ((Main)Main.Instance).PlaySound(GenericClips.SHOT);
    }

	void Update ()
    {
        if((startPosition - transform.position).sqrMagnitude > despawnDistance * despawnDistance){
            gameObject.SetActive(false);
            return;
        }
	}

    public override void Reset()
    {
        base.Reset();
        shooted = false;
        direction = Vector3.zero;
        rigidbody.velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
        caster = null;
    }

    void OnTriggerEnter(Collider col) {
        Item unit = col.GetComponent<Item>();
        if (unit as Bullet) return;
        if (unit == caster) return;

        Character character = unit as Character;
        if (character && character.team != caster.team)
        {
            caster.Hit(character);
        }

        direction = Vector3.zero;
        rigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
