using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk_Shoot : Trunk
{
	[SerializeField] private Transform shootPoint;
	[SerializeField] private GameObject bulletObj;

	private float shootRate;
	private float nextShoot;

	protected override void Start()
	{
		base.Start();

		shootRate = 1.5f;
		nextShoot = Time.time;
	}

	protected override void Update()
	{
		base.Update();

		if (Time.time > nextShoot)
		{
			Shoot();
			nextShoot = Time.time + shootRate;
		}
	}

	private void Shoot()
	{
		Instantiate(bulletObj, shootPoint.position, shootPoint.rotation);
	}
}
