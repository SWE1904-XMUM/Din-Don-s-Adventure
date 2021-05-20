using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_FollowPlayer : Ghost
{
	private float moveSpeed = 2f;
	
	private Rigidbody2D ghostRb;
	private Player player;
	
	private Vector3 directionToPlayer;
	
    protected override void Start()
    {
		base.Start();
       ghostRb = GetComponent<Rigidbody2D>();
	   
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
        ghostRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
    }
    private void  LateUpdate()
    {
        if (ghostRb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (ghostRb.velocity.x <= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}