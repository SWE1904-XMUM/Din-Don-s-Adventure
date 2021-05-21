using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Weapon : MonoBehaviour
{
	[SerializeField] private float bulletSpeed = 10f;
	[SerializeField] private float maxBulletDistance = 20f;

	private Rigidbody2D bulletRb;
	private float shootingXPosition;

	private Player player;
	private Vector2 moveDirection;

	// Start is called before the first frame update
	void Start()
	{
		// shootingXPosition gets the end point x-axis
		bulletRb = GetComponent<Rigidbody2D>();
		shootingXPosition = transform.position.x;

		//"player" represents the character (din/don)
		player = GameObject.FindObjectOfType<Player>();

		// get the direction to player
		moveDirection = (player.transform.position - transform.position).normalized;
		bulletRb.velocity = new Vector2(moveDirection.x, moveDirection.y) * bulletSpeed;

	}


	// Update is called once per frame
	void Update()
	{

		// Bullets which reach maxBulletDistance distroy.
		if (Mathf.Abs(transform.position.x - shootingXPosition) > maxBulletDistance)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D colObj)
	{
		if (colObj.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
		}
		// if this bullet collides the player, then display
		else if (colObj.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
