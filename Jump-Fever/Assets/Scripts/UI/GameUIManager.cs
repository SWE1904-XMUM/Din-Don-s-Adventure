using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("Display")]
	public Image energyBarImg;
	public RectTransform energyBar;
	public TextMeshProUGUI healthNum;
	public TextMeshProUGUI coinNum;
	public TextMeshProUGUI bulletNum;
	
	[Header("EnergyBar")]
	private float energyBarNewWidth;
	private float energyBarMaxWidth;
	private float energyBarMaxHeight;
	
	private GameObject playerGameObj;
	private Player player;
	
	private void Start()
	{
		energyBar = energyBarImg.GetComponent<RectTransform>();
		energyBarMaxWidth = energyBar.sizeDelta.x;
		energyBarMaxHeight = energyBar.sizeDelta.y;
		playerGameObj = GameObject.Find("Player");
		if(playerGameObj != null)
		{
			player = playerGameObj.GetComponent<Player>();
		}
	}
	
	private void Update()
	{
		UpdateEnergyBar();
		UpdateHealth();
		UpdateCoin();
		UpdateBullet();
	}
	
	private void UpdateEnergyBar()
	{
		energyBarNewWidth = player.energy / player.maxEnergy * energyBarMaxWidth;
		energyBar.sizeDelta = new Vector2(energyBarNewWidth,energyBarMaxHeight);
		if(player.energy < 0.3 * player.maxEnergy)
		{
			energyBarImg.color = new Color32(255,47,49,255);
		}
		else if(player.energy < 0.7 * player.maxEnergy)
		{
			energyBarImg.color = new Color32(253,255,47,255);
		}
		else if(player.energy <= player.maxEnergy)
		{
			energyBarImg.color = new Color32(83,255,91,255);
		}
	}
	
	private void UpdateHealth()
	{
		healthNum.text = player.health.ToString();
	}
	
	private void UpdateCoin()
	{
		coinNum.text = player.coin.ToString();
	}
	
	private void UpdateBullet()
	{
		bulletNum.text = player.bullet.ToString();
	}
}
