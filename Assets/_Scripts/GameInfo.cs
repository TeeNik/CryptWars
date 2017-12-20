using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo {

    public static bool IsSpawn = false;
    public static CharacterType SpawnType;

	public enum CharacterType
    {
        Goblin,
        Ranger,
        Cleric,
        Skeleton,
        Golem,
        Wizard
    }
}
