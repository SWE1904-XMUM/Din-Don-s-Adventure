using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    public Sound[] bgms;
	private string sceneNameHolder;
	private string currScene;
	private string currAudioClip;
	private string clipToPlay;
	
	void Awake()
	{
		foreach(Sound s in bgms)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = true;
		}
	}
	
	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	void Update()
	{
		//if the scene changed
		if(sceneNameHolder != SceneManager.GetActiveScene().name)
		{
			//get the new scene name
			sceneNameHolder = SceneManager.GetActiveScene().name;
			
			//get audio clip
			clipToPlay = GetSceneBGM(sceneNameHolder);
			
			//if the clip changes
			if(clipToPlay != currAudioClip && clipToPlay != null)
			{
				if(currAudioClip != null)
				{
					//stop current bgm
					Stop(currAudioClip);
				}
				
				//change currAudioClip to next clip
				currAudioClip = clipToPlay;
				
				if(currAudioClip != null)
				{
					//play next bgm
					Play(currAudioClip);
				}
			}
		}
	}
	
	public string GetSceneBGM(string sceneName)
	{
		if(sceneName == "HomeScene")
		{
			return "opening";
		}
		return null;
	}
	
	private void Play(string name)
	{
		Sound s = Array.Find(bgms, sound => sound.name == name);
		s.source.Play();
	}
	
	private void Stop(string name)
	{
		Sound s = Array.Find(bgms, sound => sound.name == name);
		s.source.Stop();
	}
}