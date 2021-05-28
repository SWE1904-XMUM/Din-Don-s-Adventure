using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollider : MonoBehaviour
{
	//collider is outside of the level
    private void OnCollisionEnter2D(Collision2D colObj)
	{
		if(colObj.gameObject.tag == "Player")
		{
			//if player hits the collider (player goes out of the level)
			Player player = colObj.gameObject.GetComponent<Player>();
			player.health -= 1;
			player.energy = player.maxEnergy;
			SendPlayerToStartPosition(colObj);
		}
	}
	
	private void SendPlayerToStartPosition(Collision2D playerObj)
	{
		//put the player back to the start position of the level
		Transform playerStartPosition = GameObject.Find("PlayerStartPosition").transform;
		if(playerStartPosition != null)
		{
			playerObj.gameObject.transform.position = playerStartPosition.position;
		}
	}
}
