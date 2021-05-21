using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : Player
{
	private float hurtForce = 4f;
	
	protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    //take damage when hitting enemy
    private void OnCollisionEnter2D(Collision2D colObj)
    {
        if(colObj.gameObject.tag == "Enemy")
        {
            TakeDamage();
			HurtMovement(colObj);
			Hurt();
        }
    }

    //take damage when hitting enemies' bullet/laser
    private void OnTriggerEnter2D(Collider2D colObj)
    {
        if(colObj.gameObject.tag == "EnemyBullet")
        {
            TakeDamage();
			Hurt();
			Destroy(colObj.gameObject);
        }
    }

    private void TakeDamage()
    {
        player.health -= 1;
    }
	
	//call from OnTriggerEnter2D()
	private void Hurt()
	{
		playerAnim.SetBool("hurt", true);
	}
	
	//call from animation
	private void EndHurt()
	{
		playerAnim.SetBool("hurt", false);
	}
	
	private void HurtMovement(Collision2D colObj)
	{
		if(colObj.transform.position.x < transform.position.x)
		{
			//shock to right
			playerRb.velocity = new Vector2(hurtForce, playerRb.velocity.y);
		}
		if(colObj.transform.position.x > transform.position.x)
		{
			//shock to left
			playerRb.velocity = new Vector2(-hurtForce, playerRb.velocity.y);
		}
		//ResetVelocity();
	}
	
	private IEnumerator ResetVelocity()
	{
		yield return new WaitForSeconds(0.8f);
		playerRb.velocity = Vector2.zero;
	}
}