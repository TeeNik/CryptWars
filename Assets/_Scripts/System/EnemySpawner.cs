using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private Field[] _fields;

    public static EnemySpawner Instance;

    private void Start()
    {
        EventHandler.Instance.SpawnEvent += SpawnWarrior;
        Instance = this;
    }

    public static Field GetField(int i)
    {
        return Instance._fields[i];
    }

    public static void SpawnWarrior(WarriorObject w)
    {
        Instance._fields[w.line].Spawn(w);
    }
}
