﻿using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

    [SerializeField]
    private Enemy enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemy.target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            print("Exit");
            enemy.target = null;
        }
    }
     

}
