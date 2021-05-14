using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionController : MonoBehaviour
{
	[SerializeField] private GameObject Din;
	[SerializeField] private GameObject Don;
	
	private SpriteRenderer playerSr;
	private Animator playerAnim;
	
	void Start()
	{
		playerSr = GetComponent<SpriteRenderer>();
		playerAnim = GetComponent<Animator>();
	}
	
    public void SelectDin()
	{
		Debug.Log("SelectDin");
		playerSr.sprite = Din.GetComponent<SpriteRenderer>().sprite;
		playerAnim.runtimeAnimatorController = Din.GetComponent<Animator>().runtimeAnimatorController as RuntimeAnimatorController;
	}
	
	public void SelectDon()
	{
		Debug.Log("SelectDon");
		playerSr.sprite = Don.GetComponent<SpriteRenderer>().sprite;
		playerAnim.runtimeAnimatorController = Don.GetComponent<Animator>().runtimeAnimatorController as RuntimeAnimatorController;
	}
}
