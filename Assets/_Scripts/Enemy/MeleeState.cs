using UnityEngine;
using System.Collections;
using System;

public class MeleeState : IEnemyState
{

    float attackTimer;
    public float attackCoolDown = 1.5f;
    bool canAttack = true;

    private Enemy enemy;

    public delegate void DamagePlayer(float damage);
    public static event DamagePlayer AttackPlayer;

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
                AttackPlayer(enemy.damage);
            }
            else
            {
                enemy.target.gameObject.GetComponent<Character>().GetDamage(enemy.damage);
            }            
        }
    }
}
