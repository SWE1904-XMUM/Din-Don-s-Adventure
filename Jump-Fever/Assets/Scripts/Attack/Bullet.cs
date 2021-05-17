using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float  maxBulletDistance = 8f;
	
	private Rigidbody2D bulletRb;
	private float shootingXPosition;

	//only applicable to player
	public float bulletPower;
	public float bulletSpeed = 8f;

	// Start is called before the first frame update
	void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
		shootingXPosition = transform.position.x;
		bulletRb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x - shootingXPosition) > maxBulletDistance)
		{
			Destroy(gameObject);
		}
    }
	
	void OnCollisionEnter2D(Collision2D colObj)
	{
		if(colObj.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
		}
	}
}
