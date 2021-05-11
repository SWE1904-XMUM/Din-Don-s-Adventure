using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	protected Player player;
	
	protected virtual void OnTriggerEnter2D(Collider2D collObj)
	{
		if(collObj.gameObject.tag == "Player")
		{
			player = collObj.GetComponent<Player>();
		}
	}
	
	protected virtual void Collect()
	{
		Destroy(gameObject);
	}
}