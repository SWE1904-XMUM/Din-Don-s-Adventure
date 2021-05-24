using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
	//enemy's attribute
<<<<<<< HEAD
	private float h = 30f;
    
    protected override void Start()
    {
      base.Start();
		  UpdateHealth();
=======
	private float h = 60f;
    
    protected override void Start()
    {
		base.Start();
		UpdateHealth();
>>>>>>> 04cb7cc5fcc5250c2ced61151370101d032c98f0
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