using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GenericClips
{
    AMBIENCE = 0,
    COIN = 1,
    SHOT = 2
}

public class Main : SceneScript {

    public Canvas gui;
    private AudioSource[] audioSources;


    protected override void BeforeGameStart()
    {
        audioSources = GetComponents<AudioSource>();
        player = spawn.Spawn();
    }

    protected override void OnGameStart(CPlayer player)
    {
        GameStats.Get.lives = 3;
        GameStats.Get.coins = 0;

        RenderLives();
    }

    public void PlaySound(GenericClips clip)
    {
        audioSources[(int)clip].Play();
    }

    public void RenderLives() {
        int lives = GameStats.Get.lives;

        UIHp[] images = gui.GetComponentsInChildren<UIHp>(true);
        for (var i = 0; i < images.Length; i++) {
            images[i].Show((i < lives));
        }

        if (lives < 0)
        {
            Application.LoadLevel(2);
        }
    }

    //GameStats Handling


    public void LooseLive()
    {
        GameStats.Get.lives--;
        RenderLives();
    }

    public void CollectCoin() {
        GameStats.Get.coins++;
    }
}
