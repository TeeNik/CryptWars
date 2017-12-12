using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler {

    public static EventHandler instance;

    public EventHandler()
    {
        instance = this;
    }

    public delegate void DamagePlayer(float damage, bool player);
    public delegate void CreateSpawnButtons(GameInfo.CharacterType[] arr);

    public event Action<WarriorObject> spawnEvent; 

}
