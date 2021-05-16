using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectable : MonoBehaviour
{
	protected Player player;
	
	//play sound effect
	private SoundEffectManager soundManager;
	
	protected virtual void OnTriggerEnter2D(Collider2D collObj)
	{
		if(collObj.gameObject.tag == "Player")
		{
			player = collObj.GetComponent<Player>();
		}
		//find SoundEffectManager
		soundManager = FindObjectOfType<SoundEffectManager>();
	}
	
	protected virtual void Collect()
	{
		if(soundManager != null)
		{
			soundManager.Play("collect");
		}
		Destroy(gameObject);
	}
}