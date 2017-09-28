﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] characters;

    private static ResourceManager inst;

    private void Start()
    {
        inst = this;
    }

    public static GameObject getCharacter(string Name)
    {
        return Get(Name + " (UnityEngine.GameObject)", inst.characters);
    }

    public static T Get<T>(string Name, T[] Array){
        print(Name);
        for (int i = 0; i < Array.Length; i++)
        {
            if (Array[i].ToString() == Name)
            {
                return Array[i];
            }
        }
        return default(T);
    }



}
