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
    float maxHealth;

    [SerializeField]
    Image heathBar;

    float curHealth;

    private void Start()
    {
        curHealth = maxHealth-20;
        Field.Spawn += test;
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //heathBar.fillAmount = curHealth / maxHealth;
    }

    [Command]
    public void CmdSpawnFromPlayer(GameObject ob)
    {
        /*if (!isLocalPlayer)
        {
            return;
        }*/
        print("end");
        print(ob);
        NetworkServer.Spawn(ob);
    }

    public void test(GameObject ob)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        print(ob);
        Instantiate(ob);
        CmdSpawnFromPlayer(ob);
    }



}
