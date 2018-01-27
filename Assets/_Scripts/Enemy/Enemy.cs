using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private IEnemyState currentState;
    public GameObject target { get; set; }
    public float meleeRange = 3;
    public float damage;
    public bool facingRight = true;
    public float speed;

    public bool inMeleeRange
    {
        get
        {
            if (target != null)
            {
                return Vector2.Distance(transform.position, target.transform.position) <= meleeRange;
            }
            return false;
        }
    }

    void Start()
    {
        ChangeState(new MoveState());

        StartCoroutine(CheckMove());
    }

    void Update()
    {
        currentState.Execute();
        LookAtTarger();

        

    }

    public IEnumerator CheckMove()
    {
        float dx = 0;
        for(int i = 0; i < 20; i++)
        {
            if(dx == 0)
            {
                dx = transform.position.x;
            } else
            {
                print(dx - transform.position.x);
                dx = transform.position.x;
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }

    private void LookAtTarger()
    {
        if(target != null)
        {
            float x = target.transform.position.x - transform.position.x;
            if (x > 0 && facingRight || x < 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }

    public void Move()
    {
        GetComponent<Animator>().SetBool("walking", true);

        GetComponent<Rigidbody2D>().velocity = GetDirection() * speed;
    }

    public Vector2 GetDirection()
    {
        return !facingRight ? Vector2.right : Vector2.left;
    }

    void OnTriggerEnter2D(Collider2D other)
    {       
        currentState.OnTriggerEnter2D(other);
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    
}
