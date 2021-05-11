using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Player
{
	[SerializeField] private Bullet bulletObj;
	[SerializeField] private Transform shootPoint;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
		if(Input.GetKeyDown(KeyCode.X))
		{
			if(bulletObj != null && shootPoint != null)
			{
				Shoot();
			}
		}
    }
	
	private void Shoot()
	{
		Instantiate(bulletObj, shootPoint.position, shootPoint.rotation);
	}
}
