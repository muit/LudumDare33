using UnityEngine;
using System.Collections;

public class ISpawn : Item {

    protected override void OnGameStart(SceneScript scene)
    {

    }

    public CPlayer Spawn(float height = 0) {
        if (!SceneScript.Instance.player)
        {
            Vector3 position = transform.position;
            position.y += height;
            return Instantiate(Cache.Get.player, position, transform.rotation) as CPlayer;
        }
        return null;
    }
}
