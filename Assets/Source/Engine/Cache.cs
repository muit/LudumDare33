using UnityEngine;
using System.Collections;

public class Cache : MonoBehaviour {
    [Header("Prefabs")]
    public CPlayer playerPrefab;
    public Coin coinPrefab;


    //Singletone
    private static Cache instance;
    public static Cache Get
    {
        get {
            return instance? instance : instance = FindObjectOfType<Cache>();
        }
        private set { instance = value; }
    }
}
