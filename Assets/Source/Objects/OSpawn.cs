using UnityEngine;
using System.Collections;

public class OSpawn : Object {
    public CPlayer playerPrefab;

    protected override void OnGameStart(SceneScript scene)
    {

    }

    public CPlayer Spawn(float height = 0) {
        if (!SceneScript.Instance.player)
        {
            Vector3 position = transform.position;
            position.y += height;
            return Instantiate(playerPrefab, position, transform.rotation) as CPlayer;
        }
        return null;
    }
}
