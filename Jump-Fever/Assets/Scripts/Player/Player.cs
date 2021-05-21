using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{	
	protected Rigidbody2D playerRb;
	protected Animator playerAnim;
	protected Collider2D playerColl;
	protected Player player;
	
	[SerializeField] private LayerMask Ground;
	
	//player's attributes
	public float health = 5f;
	public int coin = 0;
	public float energy = 100f;
	public int bullet = 30;
	
	public float maxEnergy = 100f;
	public readonly float maxBullet = 30;

	protected float hInput;
	protected float vInput;
	
    protected virtual void Start()
    {
		DontDestroyOnLoad(gameObject);
        playerRb = GetComponent<Rigidbody2D>();
		playerAnim = GetComponent<Animator>();
		playerColl = GetComponent<Collider2D>();
		player = GetComponent<Player>();
    }

    protected virtual void Update()
    {
		  if(health <= 0 || energy <= 0)
		  {
			  Death();
		  }

      HandleInput();
    }
	
	protected virtual void HandleInput()
	{
		hInput = Input.GetAxis("Horizontal");
        //vertical input is handled in playerJump
	}
	
	private void Death()
	{
		Destroy(gameObject);
		SceneManager.LoadScene("GameOverScene");
	}
	
	protected bool IsTouchingGround()
	{
		return playerColl.IsTouchingLayers(Ground);
	}
}