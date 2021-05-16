using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundEffectManager : MonoBehaviour
{
    public Sound[] soundEffects;
	
	void Awake()
	{
		foreach(Sound s in soundEffects)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}
	
	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	public void Play(string name)
	{
		Sound s = Array.Find(soundEffects, sound => sound.name == name);
		s.source.Play();
	}
	
	public void Stop(string name)
	{
		Sound s = Array.Find(soundEffects, sound => sound.name == name);
		s.source.Stop();
	}
}
