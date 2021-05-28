using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
	private GameObject player;
	private GameObject golem;
	
	private void Awake()
	{
		player = GameObject.Find("Player");
	}
	
    private void Update()
	{
		golem = GameObject.Find("Golem");
		if(golem == null)
		{
			//if golem destroyed
			Destroy(player);
			SceneManager.LoadScene("ClearScene");
		}
	}
}
