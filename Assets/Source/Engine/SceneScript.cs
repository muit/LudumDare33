using UnityEngine;

public class SceneScript : MonoBehaviour
{
    // Static singleton property
    public static SceneScript Instance { get; private set; }


    public OSpawn spawn;
    public CPlayer player;
    public CameraMovement camera;

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

    void Start()
    {
        spawn = FindObjectOfType<OSpawn>();
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