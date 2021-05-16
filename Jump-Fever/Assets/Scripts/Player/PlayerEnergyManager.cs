using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyManager : Player
{
	private float time = 0f;
	private float timeInterval = 0.5f;
	
	private float runEnergy = 2f;
	private float jumpEnergy = 3f;
	private float shootEnergy = 5f;
	private float hurtEnergy = 7f;
	
    protected override void Start()
    {
		base.Start();
    }

    protected override void Update()
    {
        base.Update();
		if(time >= timeInterval)
		{
			ManageEnergy();
			time = 0;
		}
		time += Time.deltaTime;
    }
	
	private void ManageEnergy()
	{
		if(playerAnim.GetBool("run"))
		{
			player.energy -= runEnergy;
		}
		else if(playerAnim.GetBool("jump"))
		{
			player.energy -= jumpEnergy;
		}
		else if(playerAnim.GetBool("shoot"))
		{
			player.energy -= shootEnergy;
		}
		else if(playerAnim.GetBool("Hurt"))
		{
			player.energy -= hurtEnergy;
		}
		else if(playerAnim.GetBool("idle") || playerAnim.GetBool("fall"))
		{
			player.energy -= 0;
		}
	}
}
