using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
	[Header("Available Characters")]
	[SerializeField] private GameObject Din;
	[SerializeField] private GameObject Don;
	
	[Header("Selected Character")]
	private SpriteRenderer playerSr;
	private Animator playerAnim;
	
    // Start is called before the first frame update
    void Start()
    {
		playerSr = GetComponent<SpriteRenderer>();
		playerAnim = GetComponent<Animator>();
    }

    public void SelectDin()
	{
		playerSr.sprite = Din.GetComponent<SpriteRenderer>().sprite;
		//playerAnim = Din.GetComponent<Animator>();
	}
	
	public void SelectDon()
	{
		playerSr.sprite = Don.GetComponent<SpriteRenderer>().sprite;
		//playerAnim = Don.GetComponent<Animator>();
	}
}
