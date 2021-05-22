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
			s.source.loop = s.loop;
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
		if(sceneName == "InstructionScene" || sceneName == "PlayerSelection")
		{
			
		}
		if(sceneName == "StoryScene")
		{
			
		}
		if(sceneName == "Level 1")
		{
			
		}
		if(sceneName == "Level 2")
		{
			
		}
		if(sceneName == "Level 3")
		{
			
		}
		if(sceneName == "Level 4")
		{
			
		}
		if(sceneName == "Level 5")
		{
			return "level5";
		}
		if(sceneName == "BossScene")
		{
			return "bossLevel";
		}
		if(sceneName == "ClearScene")
		{
			return "gameClear";
		}
		if(sceneName == "GameOverScene")
		{
			return "gameOver";
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