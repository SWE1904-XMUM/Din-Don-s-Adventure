using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Enemy
{
	//enemy's attribute
	[SerializeField] private float h = 20f;
    
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