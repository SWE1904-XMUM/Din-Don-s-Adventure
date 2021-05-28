using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Player
{
	private float jumpHeight = 8f;
	private bool canDoubleJump = false;
	
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
		
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(IsTouchingGround())
			{
				canDoubleJump = true;
				playerRb.velocity = new Vector2(playerRb.velocity.x * Time.fixedDeltaTime, jumpHeight);
			}
			else if(canDoubleJump)
			{
				playerRb.velocity = new Vector2(playerRb.velocity.x * Time.fixedDeltaTime, jumpHeight);
				canDoubleJump = false;
			}
		}
    }
}