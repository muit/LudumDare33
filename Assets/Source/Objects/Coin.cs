﻿using UnityEngine;
using System.Collections;

public class Coin : PickUp {
    public static void Drop(Vector3 position, int min = 0, int max = 1) {
        position.y += 1;
        int amount = Random.Range(min, max);

        for(int i = 0; i < amount; i++) {
            Coin coin = Item.Instantiate(Cache.Get.coin, position, Quaternion.identity) as Coin;
            Rigidbody rigidbody = coin.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                rigidbody.velocity = new Vector3(Random.Range(-4f, 4f), 9, Random.Range(-4f, 4f));
            }
        }
    }

	protected override void Start () {
        base.Start();
	
	}
    
    void OnTriggerEnter(Collider col) {
        CPlayer player = col.GetComponent<CPlayer>();
        if (player)
        {
            //player.CollectMoney(this);
            ((Main)Main.Instance).PlaySound(GenericClips.COIN);
            GameObject.Destroy(gameObject, 0.1f);
        }
    }

}
