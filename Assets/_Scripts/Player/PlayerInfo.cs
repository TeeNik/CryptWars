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
        if (!isLocalPlayer)
        {
            return;
        }
        print(isServer);
        var clone = Instantiate(ResourceManager.getCharacter(ob.type.ToString()), EnemySpawner.getField(ob.field).position, EnemySpawner.getField(ob.field).rotation);
        clone.transform.localScale = new Vector3(-1f, 1f, 1f);
        clone.gameObject.tag = "Enemy";
        print("spawn");
        //clone.GetComponent<Enemy>().ChangeDirection();
        NetworkServer.Spawn(clone);
    }

    public static void SetSelectedWarriors(GameInfo.CharacterType[] arr)
    {

    }



}
