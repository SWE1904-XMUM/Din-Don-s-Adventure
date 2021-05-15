using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionController : MonoBehaviour
{
	[SerializeField] private GameObject Din;
	[SerializeField] private GameObject DinBullet;
	[SerializeField] private GameObject Don;
	[SerializeField] private GameObject DonBullet;
	
	private SpriteRenderer playerSr;
	private Animator playerAnim;
	private PlayerShoot playerShoot;
	
	void Start()
	{
		playerSr = GetComponent<SpriteRenderer>();
		playerAnim = GetComponent<Animator>();
		playerShoot = GetComponent<PlayerShoot>();
	}
	
    public void SelectDin()
	{
		playerSr.sprite = Din.GetComponent<SpriteRenderer>().sprite;
		playerAnim.runtimeAnimatorController = Din.GetComponent<Animator>().runtimeAnimatorController as RuntimeAnimatorController;
		playerShoot.bulletObj = DinBullet.GetComponent<Bullet>();
	}
	
	public void SelectDon()
	{
		playerSr.sprite = Don.GetComponent<SpriteRenderer>().sprite;
		playerAnim.runtimeAnimatorController = Don.GetComponent<Animator>().runtimeAnimatorController as RuntimeAnimatorController;
		playerShoot.bulletObj = DonBullet.GetComponent<Bullet>();
	}
}
