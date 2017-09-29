using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float damage;

    private float curHealth;

    public void Start()
    {
        curHealth = maxHealth;
    }

    private void GetDamage(float d)
    {
        curHealth -= d;
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
