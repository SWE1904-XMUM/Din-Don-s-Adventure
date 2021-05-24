using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_FollowPlayer : Ghost
{
	private float moveSpeed = 2f;
	
	private Player player;
	
	private Vector3 directionToPlayer;
	
    protected override void Start()
    {
		base.Start();
	   
	   //find player in the scene
       player = FindObjectOfType<Player>();
    }

    protected override void Update()
    {
		base.Update();
        Move();
    }

    protected override void Move()
    {
		//get the direction to player
        directionToPlayer = (player.transform.position - transform.position).normalized;
		//set the velocity of ghost
        enemyRb.velocity = new Vector2(directionToPlayer.x, 0) * moveSpeed;
		
		if (enemyRb.velocity.x > 0)
        {
			//flip to right
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else if (enemyRb.velocity.x <= 0)
        {
			//flip to left
            transform.eulerAngles = new Vector3(0,0,0);
        }
    }
}