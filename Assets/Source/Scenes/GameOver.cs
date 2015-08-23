using UnityEngine;
using System.Collections;

public class GameOver : SceneScript {

    protected override void OnGameStart(CPlayer player)
    {
        if (GameStats.Get)
        {
            UITextVariable coinsText = FindObjectOfType<UITextVariable>();
            coinsText.numericValue = GameStats.Get.coins;
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
}
