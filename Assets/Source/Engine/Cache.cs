﻿using UnityEngine;
using System.Collections;

public class Cache : MonoBehaviour {
    [Header("Character Prefabs")]
    public CPlayer player;
    public CApple apple;
    public COrange orange;

    [Header("Object Prefabs")]
    public Coin coin;
    public Bullet bullet;
    public Explosion explosion;
    public Explosion smallExplosion;

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
