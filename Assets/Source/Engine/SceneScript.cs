using UnityEngine;

public class SceneScript : MonoBehaviour
{
    // Static singleton property
    public static SceneScript Instance { get; private set; }

    void Awake()
    {
        // Check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;

        //DontDestroyOnLoad(gameObject);
    }

    void Start() {
        OnGameStart(FindObjectOfType<CPlayer>());
    }


    //Events
    protected virtual void OnGameStart(CPlayer player) {}
}