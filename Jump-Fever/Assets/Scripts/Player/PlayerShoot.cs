using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Player
{
	[SerializeField] private Bullet bulletObj;
	[SerializeField] private Transform shootPoint;
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
		if(Input.GetKeyDown(KeyCode.X))
		{
			if(bulletObj != null && shootPoint != null)
			{
				//have bullet
				if(player.bullet > 0)
				{
					if(playerAnim.GetBool("jump") || playerAnim.GetBool("fall"))
					{
						Shoot();
					}
					else if(playerAnim.GetBool("idle") || playerAnim.GetBool("run"))
					{
						SwitchPlayerAnimationState();
					}
				}
			}
		}
    }
	
	private void SwitchPlayerAnimationState()
	{
		if(playerAnim.GetBool("run"))
		{
			playerAnim.SetBool("runShoot",true);
		}
		if(playerAnim.GetBool("idle"))
		{
			playerAnim.SetBool("shoot",true);
		}
	}
	
	private void Shoot()
	{
		Instantiate(bulletObj, shootPoint.position, shootPoint.rotation);
		player.bullet -= 1;
	}
	
	private void EndShoot()
	{
		if(playerAnim.GetBool("runShoot"))
		{
			playerAnim.SetBool("runShoot",false);
		}
		if(playerAnim.GetBool("shoot"))
		{
			playerAnim.SetBool("shoot",false);
		}
	}
}
