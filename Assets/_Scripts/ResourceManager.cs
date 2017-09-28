using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] characters;

    [SerializeField]
    private Transform spawnPosition;

    private static ResourceManager inst;

    private void Start()
    {
        inst = this;
    }

    public static GameObject getCharacter(string Name)
    {
        return Get(Name + " (UnityEngine.GameObject)", inst.characters);
    }

    public static Transform getSpawnPosition()
    {
        return inst.spawnPosition;
    }

    public static T Get<T>(string Name, T[] Array){
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
