using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerInfo : NetworkBehaviour
{

    int coin;
    int energy;

    public GameObject obj;
    public Transform place;

    [SerializeField]
    private GameInfo.CharacterType[] selectedWarriors;

    private void Start()
    {
        Field.Spawn += CmdSpawnFromPlayer;
    }

    [Command]
    public void CmdSpawnFromPlayer(EnemySpawnObject ob)
    {
        if (!isLocalPlayer || isServer)
        {
            return;
        }
        print(isServer);
        var clone = (GameObject)Instantiate(ResourceManager.getCharacter(ob.type.ToString()), EnemySpawner.getField(ob.field).position, EnemySpawner.getField(ob.field).rotation);
        clone.GetComponent<Enemy>().ChangeDirection();
        NetworkServer.Spawn(clone);
    }

    public static void SetSelectedWarriors(GameInfo.CharacterType[] arr)
    {

    }



}
