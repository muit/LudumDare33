using UnityEngine;
using System.Collections;

public enum GenericClips
{
    AMBIENCE = 0,
    COIN = 1,
    SHOT = 2
}

public class Main : SceneScript {

    private AudioSource[] audioSources;


    protected override void BeforeGameStart()
    {
        audioSources = GetComponents<AudioSource>();
        player = spawn.Spawn();
    }

    protected override void OnGameStart(CPlayer player)
    {
        
    }

    public void PlaySound(GenericClips clip) {
        audioSources[(int)clip].Play();
    }
}
