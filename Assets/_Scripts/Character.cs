using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;

    private float curHealth;

    public void Start()
    {
        curHealth = maxHealth;
    }

    public void Update()
    {
        //StartMove();
    }

    private void GetDamage(float d)
    {
        curHealth -= d;
        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void StartMove()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}
