using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Collectable
{
    protected override void OnTriggerEnter2D(Collider2D collObj)
	{
		base.OnTriggerEnter2D(collObj);
		Collect();
	}
	
	protected override void Collect()
	{
		player.energy = player.energy + 30;
		if(player.energy >= 100)
		{
			player.energy = 100;
		}
		base.Collect();
	}
}
