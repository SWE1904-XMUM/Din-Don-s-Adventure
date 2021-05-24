using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colObj)
	{
		if(colObj.gameObject.tag == "Player")
		{
			Player player = colObj.gameObject.GetComponent<Player>();
			player.health -= 1;
			player.energy = player.maxEnergy;
			SendPlayerToStartPosition(colObj);
		}
	}
	
	private void SendPlayerToStartPosition(Collision2D playerObj)
	{
		Transform playerStartPosition = GameObject.Find("PlayerStartPosition").transform;
		if(playerStartPosition != null)
		{
			playerObj.gameObject.transform.position = playerStartPosition.position;
		}
	}
}
