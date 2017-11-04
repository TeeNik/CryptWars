using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnObject {
    public GameInfo.CharacterType type;
    public int field;

    public EnemySpawnObject()
    {
        type = 0;
        field = 0;
    }

    public EnemySpawnObject(GameInfo.CharacterType t, int f)
    {
        type = t;
        field = f;
    }
}
