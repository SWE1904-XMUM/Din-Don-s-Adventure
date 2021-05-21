using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
	//enemy's attribute
	[SerializeField] private float h = 180f;
	private Player player;

	protected override void Start()
	{
		base.Start();
		player = GameObject.Find("Player").GetComponent<Player>();
		UpdateHealth();
	}

	protected override void Update()
	{
		base.Update();
		FlipToPlayerDirection();
	}

	private void UpdateHealth()
	{
		health = h;
	}
	
	private void FlipToPlayerDirection()
	{
		if(transform.position.x <= player.transform.position.x)
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		else
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}
	
	protected override void Death()
	{
		enemyAnim.SetBool("die",true);
	}
	
	private void DestroyEnemy()
	{
		Destroy(gameObject);
	}
}
