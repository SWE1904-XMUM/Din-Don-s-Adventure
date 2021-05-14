using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Fly : Bat
{
	[SerializeField] private Transform endPoint;
	
	private float moveSpeed = 3f;
	
	private Vector3 startPosition;
	private Vector3 endPosition;
	
	private float leftXLimit;
	private float rightXLimit;
	private float upYLimit;
	private float downYLimit;
	
	private Vector2 moveVelocity;
	
	private int moveDirection;
	
    protected override void Start()
    {
        base.Start();
		
		startPosition = transform.position;
		endPosition = endPoint.position;
		leftXLimit = Mathf.Min(startPosition.x, endPosition.x);
		rightXLimit = Mathf.Max(startPosition.x, endPosition.x);
		upYLimit = Mathf.Max(startPosition.y, endPosition.y);
		downYLimit = Mathf.Min(startPosition.y, endPosition.y);
		
		//calculate the velocity of enemy
		GetMoveVelocity();
		
		if(startPosition.x <= endPosition.x)
		{
			//move to left
			moveDirection = -1;
		}
		else if(startPosition.x > endPosition.x)
		{
			//move to right
			moveDirection = 1;
		}
		
		if(leftXLimit == rightXLimit)
		{
			//move vertically
			enemyRb.velocity = moveVelocity * moveDirection;
		}
    }

    protected override void Update()
    {
        base.Update();
		Move();

		if(transform.position.x < leftXLimit)
		{
			FlipToRight();
		}
		if(transform.position.x > rightXLimit)
		{
			FlipToLeft();
		}
    }
	
	protected override void Move()
	{
		if(leftXLimit == rightXLimit)
		{
			if(transform.position.y > upYLimit)
			{
				transform.position = new Vector3(transform.position.x, upYLimit, transform.position.z);
				enemyRb.velocity = new Vector2(enemyRb.velocity.x, -enemyRb.velocity.y);
			}
			if(transform.position.y < downYLimit)
			{
				transform.position = new Vector3(transform.position.x, downYLimit, transform.position.z);
				enemyRb.velocity = new Vector2(enemyRb.velocity.x, -enemyRb.velocity.y);
			}
		}
		else
		{
			enemyRb.velocity = moveVelocity * moveDirection;
		}
	}
	
	private void FlipToRight()
	{
		transform.position = new Vector2(leftXLimit, transform.position.y);
		moveDirection *= -1;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	private void FlipToLeft()
	{
		transform.position = new Vector2(rightXLimit, transform.position.y);
		moveDirection *= -1;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	private void GetMoveVelocity()
	{
		moveVelocity = new Vector2(endPosition.x - startPosition.x, endPosition.y - startPosition.y).normalized * moveSpeed;
	}
}