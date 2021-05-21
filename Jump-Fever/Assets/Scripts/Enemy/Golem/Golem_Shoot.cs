using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Shoot : Golem
{
	[SerializeField] private Transform shootPoint;
	[SerializeField] private GameObject bulletObjArm;
	[SerializeField] private GameObject bulletObjLaser;

	private float shootRate;
	private float nextShootForArm;
	private float nextShootForLaser;

	// Start is called before the first frame update
	protected override void Start()
	{
		base.Start();

		shootRate = 1.7f;
		nextShootForArm = Time.time;
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();

		Shoot();
	}

	private void Shoot()
	{

		if (Time.time > nextShootForArm)
		{

			Instantiate(bulletObjArm, transform.position, Quaternion.identity);

			nextShootForLaser = Time.time + shootRate;
			nextShootForArm = Time.time + shootRate * 2;
		}
		if (Time.time > nextShootForLaser)
		{

			Instantiate(bulletObjLaser, transform.position, Quaternion.identity);
			nextShootForLaser = Time.time + shootRate * 4;
		}
	}
}

