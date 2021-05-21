using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Bullet : Bullet
{
	private Player player;
	
	//get the direction the bullet will move
	private Vector2 moveDirection;

	protected override void Start()
	{
		// shootingXPosition gets the end point x-axis
		bulletRb = GetComponent<Rigidbody2D>();
		shootingXPosition = transform.position.x;

		//"player" represents the character (din/don)
		player = GameObject.FindObjectOfType<Player>();

		// get the direction to player
		moveDirection = (player.transform.position - transform.position).normalized;
		
		//set the velocity of bullet
		bulletRb.velocity = new Vector2(moveDirection.x, moveDirection.y) * bulletSpeed;
		
		//flip the bullet
		if(moveDirection.x <= 0)
		{
			//flip to left
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else
		{
			//flip to right
			transform.localScale = new Vector3(1, 1, 1);
		}
		
		//rotate the bullet
		transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(moveDirection.y / moveDirection.x) * 60);
	}
}
