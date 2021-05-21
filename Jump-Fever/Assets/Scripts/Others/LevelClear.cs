using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour
{
	[SerializeField] private string sceneName;
	private Player player;
	private Bullet playerBullet;
	
    private void OnTriggerEnter2D(Collider2D colObj)
	{
		if(colObj.gameObject.GetComponent<Player>() != null)
		{
			player = colObj.gameObject.GetComponent<Player>();
			playerBullet = player.GetComponent<PlayerShoot>().bulletObj;
			UpdatePlayerAttributes();
		}
		ChangeScene();
	}
	
	private void UpdatePlayerAttributes()
	{
		player.health += 1;
		player.maxEnergy += 10;
		playerBullet.bulletPower += (player.coin / 10f);
		player.coin = 0;
		player.energy = player.maxEnergy;
	}
	
	private void ChangeScene()
	{
		SceneManager.LoadScene(sceneName);
	}
}
