using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    private GameObject backgroundMusicHolder;
	private AudioSource bgm;
	
    void Start()
    {
		backgroundMusicHolder = GameObject.Find("BGMHolder");
		if(backgroundMusicHolder != null)
		{
			bgm = backgroundMusicHolder.GetComponent<AudioSource>();
			if(bgm != null)
			{
				bgm.Play();
			}
		}
    }
}
