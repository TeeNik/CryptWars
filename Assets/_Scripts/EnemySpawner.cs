using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private Transform[] fields;

    public static EnemySpawner inst;

    private void Start()
    {
        inst = this;
    }

    public static Transform getField(int i)
    {
        return inst.fields[i];
    }
}
