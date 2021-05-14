using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
	//enemy's attribute
	private float h = 30f;
    
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