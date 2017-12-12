using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private Field[] fields;

    public static EnemySpawner inst;

    private void Start()
    {
        EventHandler.spawnEvent += SpawnWarrior;
        inst = this;
    }

    public static Field getField(int i)
    {
        return inst.fields[i];
    }

    public static void SpawnWarrior(WarriorObject w)
    {
        inst.fields[w.line].Spawn(w);
    }
}
