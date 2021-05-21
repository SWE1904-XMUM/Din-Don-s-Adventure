using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Shoot : Golem
{
	[SerializeField] private Transform shootPoint;
	[SerializeField] private GameObject bulletObjArm;
	[SerializeField] private GameObject bulletObjLaser;

	private float shootRate = 1.7f;
	private float nextShootForArm;
	private float nextShootForLaser;

	protected override void Start()
	{
		base.Start();

		nextShootForArm = Time.time;
	}

	protected override void Update()
	{
		base.Update();

		Shoot();
	}

	private void Shoot()
	{
		if (Time.time >= nextShootForArm)
		{
			//release arm bullet
			Instantiate(bulletObjArm, transform.position, Quaternion.identity);

			nextShootForLaser = Time.time + shootRate;
			nextShootForArm = Time.time + shootRate * 2;
		}
		
		//release laser
		if (Time.time >= nextShootForLaser)
		{

			Instantiate(bulletObjLaser, transform.position, Quaternion.identity);
			nextShootForLaser = Time.time + shootRate * 4;
		}
	}
}

