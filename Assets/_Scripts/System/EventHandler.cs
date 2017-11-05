using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    public delegate void SpawnFromPlayer(EnemySpawnObject clone);
    public event SpawnFromPlayer Spawn;

    public EventHandler inst;

    void Start()
    {
        inst = this;
    }
}
