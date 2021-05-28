using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Patrol : Rock
{	
	[SerializeField] private Transform endPoint;
	private float moveSpeed = 1f;

	private Vector3 startPosition;
	private Vector3 endPosition;

	private float leftXLimit;
	private float rightXLimit;

	private int moveDirection;
	
	
    // Start is called before the first frame update
    protected override void Start()
    {
		base.Start();

		startPosition = transform.position;
		endPosition = endPoint.position;
		leftXLimit = Mathf.Min(startPosition.x, endPosition.x);
		rightXLimit = Mathf.Max(startPosition.x, endPosition.x);
        
    }

    // Update is called once per frame
    protected override void Update()
    {
		base.Update();
		Move();	
    }
	
	protected override void Move()
	{
		enemyRb.velocity = new Vector2(moveDirection * moveSpeed, enemyRb.velocity.y);
		
		if(transform.position.x >= rightXLimit)
		{
			//flip the stone to left
			moveDirection = -1;
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		if(transform.position.x <= leftXLimit)
		{
			//flip the stone to right
			moveDirection = 1;
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}
	
}
