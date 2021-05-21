using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : Player
{
	private float runSpeed = 6f;
	
	// Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
		if(hInput != 0)
		{	
			Run();
		}
    }
	
	private void Run()
	{
		if(hInput < 0)
		{
			playerRb.velocity = new Vector2(-runSpeed, playerRb.velocity.y);
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		if(hInput > 0)
		{
			playerRb.velocity = new Vector2(runSpeed, playerRb.velocity.y);
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}
}