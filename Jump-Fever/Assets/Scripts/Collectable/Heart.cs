using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collectable
{
    protected override void OnTriggerEnter2D(Collider2D collObj)
	{
		base.OnTriggerEnter2D(collObj);
		Collect();
	}
	
	protected override void Collect()
	{
		player.health = player.health + 1;
		base.Collect();
	}
}
