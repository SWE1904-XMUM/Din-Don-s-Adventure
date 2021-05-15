using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : Player
{
	public Bullet bulletObj;
	[SerializeField] private Transform shootPoint;
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
		Scene currScene = SceneManager.GetActiveScene();
		if(currScene.name == "PlayerSelectionScene")
		{
			//do not allow player to shoot in PlayerSelectionScene
			return;
		}
		
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
