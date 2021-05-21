using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
	//enemy's attribute
	[SerializeField] private float h = 40f;

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

	protected override void TakeDamage(float damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Death();
		}
	}
}
