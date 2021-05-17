using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D enemyRb;
	protected SpriteRenderer enemySr;
    protected Animator enemyAnim;
    
    //enemies' attributes
    public float health;
    
    protected virtual void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
		if(health <= 0)
		{
			Death();
		}
    }
	
	protected void OnTriggerEnter2D(Collider2D colObj)
	{
		//hit by player bullet
		if(colObj.gameObject.tag == "PlayerBullet")
		{
			Bullet bullet = colObj.gameObject.GetComponent<Bullet>();
			TakeDamage(bullet.bulletPower);
			Destroy(colObj.gameObject);
		}
	}
	
	protected virtual void TakeDamage(float damage)
	{
		health -= damage;
	}

    protected virtual void Move()
    {
      //walk or run or fly
    }

    protected virtual void Attack()
    {
      //shoot bullet or laser
    }
	
	protected void Death()
	{
		Destroy(gameObject);
	}
}