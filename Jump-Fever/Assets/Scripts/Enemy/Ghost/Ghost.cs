using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{    private float h = 60f;
    
    protected override void Start()
    {
		base.Start();
		UpdateHealth();
 }

    protected override void Update()
    {
        base.Update();
    }
	
	private void UpdateHealth()
	{
		health = h;
	}
}    