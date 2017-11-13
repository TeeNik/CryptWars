using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerHealth : NetworkBehaviour
{
    [SerializeField]
    float maxHealth;

    float curHealth;

    [SerializeField]
    private bool player;

    void Start () {
        curHealth = maxHealth - 20;
        MeleeState.AttackPlayer += TakeDamage;
    }
	
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        ResourceManager.inst.healthBar.fillAmount = curHealth / maxHealth;
    }

    void TakeDamage(float d, bool p)
    {
        if(player == p)
        {
            print("Damage");
            curHealth -= d;
        }
    }
}
