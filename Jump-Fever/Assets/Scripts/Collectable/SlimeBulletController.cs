using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlimeBulletController : MonoBehaviour
{
	//change the slime bullet to the selectde character's bullet
	[SerializeField] private GameObject Din;
	[SerializeField] private GameObject Don;
	[SerializeField] GameObject DinBulletCollectable;
	[SerializeField] GameObject DonBulletCollectable;
	
	private SpriteRenderer bulletSr;
	private Animator bulletAnim;
	
	private GameObject playerGameObj;
	
	//change the sprite and animator of bullet based on the player selected
	private void Start()
	{
		//get the bullet attributes
		bulletSr = GetComponent<SpriteRenderer>();
		bulletAnim = GetComponent<Animator>();
		
		//get the player in the scene
		playerGameObj = FindObjectOfType<Player>().gameObject;
		
		//change the bullet collectable
		ChangeBulletCollectable();
	}
	
	private void ChangeBulletCollectable()
	{
		if(playerGameObj.GetComponent<Animator>().runtimeAnimatorController == Din.GetComponent<Animator>().runtimeAnimatorController)
		{
			//change the bullet to din's bullet
			ToDinBullet();
		}
		if(playerGameObj.GetComponent<Animator>().runtimeAnimatorController == Don.GetComponent<Animator>().runtimeAnimatorController)
		{
			//change the bullet to don's bullet
			ToDonBullet();
		}
	}
	
	private void ToDinBullet()
	{
		//change sprite and animator
		bulletSr.sprite = DinBulletCollectable.GetComponent<SpriteRenderer>().sprite;
		bulletAnim.runtimeAnimatorController = DinBulletCollectable.GetComponent<Animator>().runtimeAnimatorController as RuntimeAnimatorController;
	}
	
	private void ToDonBullet()
	{
		change sprite and animator
		bulletSr.sprite = DonBulletCollectable.GetComponent<SpriteRenderer>().sprite;
		bulletAnim.runtimeAnimatorController = DonBulletCollectable.GetComponent<Animator>().runtimeAnimatorController as RuntimeAnimatorController;
	}
}
