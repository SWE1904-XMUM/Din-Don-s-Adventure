using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTextController : MonoBehaviour
{
	[SerializeField] Transform stopPosition;
	private Rigidbody2D storyTextRb;
	private float moveSpeed = 80f;
	
	private GameObject nextButton;
	
    // Start is called before the first frame update
    void Start()
    {
		storyTextRb = GetComponent<Rigidbody2D>();
		storyTextRb.velocity = new Vector2(0, moveSpeed);
		nextButton = GameObject.Find("NextButton");
		nextButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(storyTextRb.position.y >= stopPosition.position.y)
		{
			storyTextRb.velocity = new Vector2(0, 0);
			storyTextRb.position = stopPosition.position;
			Invoke("EnableNextButton",1);
		}
    }
	
	private void EnableNextButton()
	{
		nextButton.SetActive(true);
	}
}
