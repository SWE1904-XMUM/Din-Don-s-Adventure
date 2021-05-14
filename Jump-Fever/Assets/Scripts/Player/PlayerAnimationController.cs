using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : Player
{
    // Update is called once per frame
    private void FixedUpdate()
    {
		ResetBool();
		
		//is touching ground
		if(IsTouchingGround())
		{
			playerAnim.SetBool("jump", false);
			playerAnim.SetBool("fall", false);
		}
		else if(playerRb.velocity.y > 1f)
		{
			if(playerAnim.GetBool("fall"))
			{
				playerAnim.SetBool("fall", false);
			}
			playerAnim.SetBool("jump", true);
		}
		else if(playerRb.velocity.y < -1f)
		{
			playerAnim.SetBool("fall", true);
		}
		else if(playerRb.velocity.x != 0)
		{
			playerAnim.SetBool("run", true);
		}
		else
		{
			playerAnim.SetBool("idle",true);
		}
    }
	
	private void ResetBool()
	{
		playerAnim.SetBool("run", false);
		playerAnim.SetBool("jump", false);
		playerAnim.SetBool("fall", false);
		playerAnim.SetBool("run", false);
	}
}
