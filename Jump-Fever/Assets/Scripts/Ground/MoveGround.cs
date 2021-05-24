using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
	[SerializeField] private Transform endPoint;
	
	private Rigidbody2D groundRb;
	
	private float moveSpeed = 3f;
	
	private Vector3 startPosition;
	private Vector3 endPosition;
	
	private float leftXLimit;
	private float rightXLimit;
	private float upYLimit;
	private float downYLimit;
	
	private Vector2 moveVelocity;
	
	private int moveDirection;
	
    private void Start()
    {
		groundRb = GetComponent<Rigidbody2D>();
		
		startPosition = transform.position;
		endPosition = endPoint.position;
		leftXLimit = Mathf.Min(startPosition.x, endPosition.x);
		rightXLimit = Mathf.Max(startPosition.x, endPosition.x);
		upYLimit = Mathf.Max(startPosition.y, endPosition.y);
		downYLimit = Mathf.Min(startPosition.y, endPosition.y);
		
		//calculate the velocity of ground
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
			groundRb.velocity = moveVelocity * moveDirection;
		}
    }

    private void Update()
    {
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
	
	private void Move()
	{
		if(leftXLimit == rightXLimit)
		{
			if(transform.position.y > upYLimit)
			{
				transform.position = new Vector3(transform.position.x, upYLimit, transform.position.z);
				groundRb.velocity = new Vector2(groundRb.velocity.x, -groundRb.velocity.y);
			}
			if(transform.position.y < downYLimit)
			{
				transform.position = new Vector3(transform.position.x, downYLimit, transform.position.z);
				groundRb.velocity = new Vector2(groundRb.velocity.x, -groundRb.velocity.y);
			}
		}
		else
		{
			groundRb.velocity = moveVelocity * moveDirection;
		}
	}
	
	private void FlipToRight()
	{
		transform.position = new Vector2(leftXLimit, transform.position.y);
		moveDirection *= -1;
	}
	
	private void FlipToLeft()
	{
		transform.position = new Vector2(rightXLimit, transform.position.y);
		moveDirection *= -1;
	}
	
	private void GetMoveVelocity()
	{
		moveVelocity = new Vector2(endPosition.x - startPosition.x, endPosition.y - startPosition.y).normalized * moveSpeed;
	}
}