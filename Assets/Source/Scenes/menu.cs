using UnityEngine;
using System.Collections;

public class Menu : SceneScript {

    protected override void OnGameStart(CPlayer player)
    {
        
    }
	
	void Update ()
    {
	
	}

    public void Quit() {
        Application.Quit();
    }

    public void LoadScene(int scene) {
        Application.LoadLevelAsync(scene);
    }
}
