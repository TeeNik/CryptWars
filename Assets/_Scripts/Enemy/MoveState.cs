using UnityEngine;
using System.Collections;
using System;

public class MoveState : IEnemyState
{
    private Enemy enemy;

    float patrolTimer;


    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.GetComponent<Animator>().SetBool("attack", false);
        enemy.GetComponent<Animator>().SetBool("walking", true);
    }

    public void Execute()
    {
        enemy.Move();

        if(enemy.target != null && enemy.inMeleeRange)
        {
            enemy.ChangeState(new MeleeState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

    }

}
