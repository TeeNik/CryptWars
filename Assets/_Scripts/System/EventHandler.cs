using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler {

    public static EventHandler Instance;

    public EventHandler()
    {
        Instance = this;
    }

    public delegate void DamagePlayer(float damage, bool player);
    public delegate void CreateSpawnButtons(GameInfo.CharacterType[] arr);

    public event Action<WarriorObject> SpawnEvent; 

    

}
