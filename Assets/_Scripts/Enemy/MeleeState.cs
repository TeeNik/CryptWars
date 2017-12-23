using UnityEngine;
using System.Collections;
using System;

public class MeleeState : IEnemyState
{

    float attackTimer;
    public float attackCoolDown = 1.5f;
    bool canAttack = true;

    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Attack();
        if(!enemy.inMeleeRange)
        {
            enemy.ChangeState(new MoveState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;
        enemy.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;


        if (attackTimer >= attackCoolDown)
        {
            canAttack = true;
            attackTimer = 0;
        }

        if(canAttack)
        {
            canAttack = false;
            enemy.GetComponent<Animator>().SetBool("attack", true);

            if(enemy.target.gameObject.tag == "Castle")
            {
                Debug.Log("attack player");
                //AttackPlayer(enemy.damage, true);
            }
            else
            {
                enemy.target.gameObject.GetComponent<Character>().TakeDamage(enemy.damage);
            }            
        }
    }
}
