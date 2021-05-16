using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundEffectPlayer : MonoBehaviour
{
	[HideInInspector] public SoundEffectManager soundManager;
	
	void Start()
	{
		soundManager = FindObjectOfType<SoundEffectManager>();
	}
	
    public void Play(string name)
	{
		soundManager.Play(name);
	}
	
	public void Stop(string name)
	{
		soundManager.Stop(name);
	}
}
