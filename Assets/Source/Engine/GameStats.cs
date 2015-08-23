using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour
{
    // Static singleton property
    public static GameStats Instance { get; private set; }

    void Awake()
    {
        // Check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public int lives = 3;
    public int coins = 0;
}