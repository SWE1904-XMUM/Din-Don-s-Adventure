using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Player
{
	private float jumpHeight = 8f;
	private float jumpCount = 0;
	
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
				playerRb.velocity = new Vector2(playerRb.velocity.x * Time.fixedDeltaTime, jumpHeight);
				jumpCount += 1;
			}
			else if(jumpCount == 1)
			{
				playerRb.velocity = new Vector2(playerRb.velocity.x * Time.fixedDeltaTime, jumpHeight);
				jumpCount += 1;
			}
		}
		if(jumpCount >= 2 && IsTouchingGround())
		{
			jumpCount = 0;
		}
    }
}