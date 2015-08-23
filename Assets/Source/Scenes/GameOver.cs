using UnityEngine;
using System.Collections;

public class GameOver : SceneScript {

    protected override void OnGameStart(CPlayer player)
    {
        if (GameStats.Instance)
        {
            UITextVariable coinsText = FindObjectOfType<UITextVariable>();
            coinsText.numericValue = GameStats.Instance.coins;
        }
    }
	
    void Update ()
    {
	
    }

    public void GoMenu() {
        LoadScene(0);
    }

    public void GoGame() {
        LoadScene(1);
    }

    public void LoadScene(int scene) {
        Application.LoadLevelAsync(scene);
    }
}
