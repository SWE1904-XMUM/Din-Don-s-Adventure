using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : Player
{
	private float hurtForce = 4f;
	
	//shield given when player hurt by hitting the enemy
	private bool shieldActive = false;
	private float shieldTimer;
	private float hurtShieldMaxTime = 8f;
	
	private GameObject shieldObject;
	
	protected override void Start()
    {
        base.Start();
		shieldObject = GameObject.Find("BubbleShield");
		shieldObject.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();
		if(shieldActive == true)
		{
			shieldObject.SetActive(true);
			shieldTimer += Time.fixedDeltaTime;
			
			//exceed shield max time
			if(shieldTimer >= hurtShieldMaxTime)
			{
				//deactivate shield
				shieldObject.SetActive(false);
				shieldActive = false;
			}
		}
    }

    //take damage when hitting enemy
    private void OnCollisionEnter2D(Collision2D colObj)
    {
        if(colObj.gameObject.tag == "Enemy")
        {
            if(shieldActive == false)
			{
				TakeDamage();
				HurtMovement(colObj);
				Hurt();
				
				//activate shield
				shieldActive = true;
				shieldTimer = 0;
			}
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
	}
}