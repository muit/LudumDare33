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

    [System.NonSerialized]
    public ISpawn spawn;
    [System.NonSerialized]
    public CPlayer player;
    [System.NonSerialized]
    public CameraMovement camera;

    void Start()
    {
        spawn = FindObjectOfType<ISpawn>();
        BeforeGameStart();

        if (!player)
        {
            player = FindObjectOfType<CPlayer>();
        }

        if (!camera)
        {
            camera = FindObjectOfType<CameraMovement>();
            if (camera) camera.SetTarget(player);
        }

        OnGameStart(player);
    }


    //Events
    protected virtual void BeforeGameStart() { }
    protected virtual void OnGameStart(CPlayer player) {}
}