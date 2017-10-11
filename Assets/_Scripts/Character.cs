using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float damage;

    [SerializeField]
    private float curHealth;

    public void Start()
    {
        curHealth = maxHealth;
    }

    public void GetDamage(float d)
    {
        print(d);
        curHealth -= d;
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
