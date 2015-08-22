using UnityEngine;
using System.Collections;

public class Main : SceneScript {

    protected override void BeforeGameStart()
    {
        player = spawn.Spawn();
    }

    protected override void OnGameStart(CPlayer player)
    {
        
    }

    public void Quit() {
        Application.Quit();
    }

    public void LoadScene(int scene) {
        Application.LoadLevelAsync(scene);
    }
}
