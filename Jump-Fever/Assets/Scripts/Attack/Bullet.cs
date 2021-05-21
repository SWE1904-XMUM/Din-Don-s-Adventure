using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] protected float bulletSpeed = 8f;
	[SerializeField] protected float  maxBulletDistance = 8f;
	
	protected Rigidbody2D bulletRb;
	protected float shootingXPosition;

	//only applicable to player
	public float bulletPower;
	
	protected virtual void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
		shootingXPosition = transform.position.x;
		bulletRb.velocity = transform.right * bulletSpeed;
    }

    protected void Update()
    {
        if(Mathf.Abs(transform.position.x - shootingXPosition) > maxBulletDistance)
		{
			Destroy(gameObject);
		}
    }
	
	protected void OnCollisionEnter2D(Collision2D colObj)
	{
		//bullet will be destroyed when hiting ground
		if(colObj.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
		}
	}	
}
