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
		
		//get the time of next shoot
		nextShootForArm = Time.time;
	}

	protected override void Update()
	{
		base.Update();

		if(!enemyAnim.GetBool("die"))
		{
			//shoot if golem is not die
			Shoot();
		}
	}

	private void Shoot()
	{
		if (Time.time >= nextShootForArm)
		{
			//release arm bullet
			Instantiate(bulletObjArm, shootPoint.transform.position, Quaternion.identity);
			
			//get the time of next shoot
			nextShootForLaser = Time.time + shootRate;
			nextShootForArm = Time.time + shootRate * 2;
		}
		
		//release laser
		if (Time.time >= nextShootForLaser)
		{
			Instantiate(bulletObjLaser, shootPoint.transform.position, Quaternion.identity);
			
			//get the time of next shoot (laser)
			nextShootForLaser = Time.time + shootRate * 4;
		}
	}
}

