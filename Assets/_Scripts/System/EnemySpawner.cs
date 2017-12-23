using System.Collections;
using System.Collections.Generic;
using Assets._Scripts.CallbackObjects;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private Field[] _fields;

    public static EnemySpawner Instance;

    private void Start()
    {
        Instance = this;
    }

    public Field GetField(int i)
    {
        return Instance._fields[i];
    }

    public void SpawnWarrior(WarriorObject w)
    {
        Instance._fields[w.Line].Spawn(w);
    }
}
