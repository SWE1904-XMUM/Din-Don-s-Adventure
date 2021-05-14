using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : Player
{
	protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    //take damage when hitting enemy
    private void OnColliderEnter2D(Collision2D colObj)
    {
        if(colObj.gameObject.tag =="Enemy")
        {
            TakeDamage();
			Debug.Log("Health: " + player.health);
        }
    }

    //take damage when hitting enemies' bullet/laser
    private void OnTriggerEnter2D(Collider2D colObj)
    {
        if(colObj.gameObject.tag == "EnemyBullet")
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        player.health -= 1;
    }
}