using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPositionController : MonoBehaviour
{
	//put this object in the position the player will be placed at the beginning of each level
	private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
		//find the player
        player = GameObject.Find("Player");
		//put the player at the start position
		player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
