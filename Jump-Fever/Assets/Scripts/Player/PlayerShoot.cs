using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerShoot : Player
{
	public Bullet bulletObj;
	[SerializeField] private Transform shootPoint;
	
	//record current time
	private float timer = 0;
	//time interval until the next shoot
	private float shootInterval = 1f;
	
	//play sound effect
	private SoundEffectManager soundManager;
    
    protected override void Start()
    {
        base.Start();
		//find SoundEffectManager
		soundManager = FindObjectOfType<SoundEffectManager>();
    }

    protected override void Update()
    {
		Scene currScene = SceneManager.GetActiveScene();
		if(currScene.name == "PlayerSelectionScene")
		{
			//do not allow player to shoot in PlayerSelectionScene
			return;
		}
		if(bulletObj == null || shootPoint == null)
		{
			return;
		}
		
        base.Update();
		
		//update timer
		timer += Time.fixedDeltaTime;
		
		if(timer >= shootInterval)
		{
			if(Input.GetKeyDown(KeyCode.X))
			{
				//have bullet
				if(player.bullet > 0)
				{
					if(playerAnim.GetBool("jump") || playerAnim.GetBool("fall"))
					{
						//play shooting sound effect
						soundManager.Play("playerShoot");
						//shoot out bullet
						Shoot();
					}
					else if(playerAnim.GetBool("idle") || playerAnim.GetBool("run"))
					{
						//if player is in idle or running state,
						//change the state to shoot or runShoot
						SwitchPlayerAnimationState();
					}
					//reset the timer
					timer = 0;
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
	
	//jump & fall: call from Update()
	//idle & run: call from animation
	private void Shoot()
	{
		Instantiate(bulletObj, shootPoint.position, shootPoint.rotation);
		player.bullet -= 1;
	}
	
	//jump & fall: no state change of animation
	//idle & run: call from animation
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
