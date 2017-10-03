using UnityEngine;
using System.Collections;
using System;

public class IdleState : IEnemyState
{

    float attackTimer;
    float attackCoolDown = 3;
    bool canAttack = true;

    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Idle();
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    private void Idle()
    {
        enemy.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        enemy.GetComponent<Animator>().SetBool("isWalking", false);
    }
}
