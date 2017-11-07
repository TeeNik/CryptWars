using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Character : NetworkBehaviour
{

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float damage;

    //[SerializeField]
    [SyncVar(hook = "OnChangeHealth")]
    private float curHealth;

    [SerializeField]
    private Image healthBar;

    public void Start()
    {
        curHealth = maxHealth;
    }

    void OnChangeHealth(float hp)
    {
        healthBar.fillAmount = hp / maxHealth;
    }

    public void TakeDamage(float d)
    {
        curHealth -= d;
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
