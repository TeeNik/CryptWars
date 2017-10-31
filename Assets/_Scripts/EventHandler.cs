using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler {

    public delegate void SpawnFromPlayer(GameObject clone);

    public static event SpawnFromPlayer Spawn;


}
