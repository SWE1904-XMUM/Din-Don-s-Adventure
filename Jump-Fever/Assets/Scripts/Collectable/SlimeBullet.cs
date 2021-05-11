using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : Collectable
{
    protected override void OnTriggerEnter2D(Collider2D collObj)
	{
		base.OnTriggerEnter2D(collObj);
		Collect();
	}
	
	protected override void Collect()
	{
		player.bullet = player.bullet + 5;
		base.Collect();
	}
}
