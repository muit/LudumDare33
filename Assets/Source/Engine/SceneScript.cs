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
        CPlayer player = GameObject.FindObjectOfType<CPlayer>();
        OnGameStart(player);
    }

    protected virtual void OnGameStart(CPlayer player) {}
}