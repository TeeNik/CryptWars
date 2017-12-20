using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
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
        ResourceManager.Instance.healthBar.fillAmount = curHealth / maxHealth;
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
