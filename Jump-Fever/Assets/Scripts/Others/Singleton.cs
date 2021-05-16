using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance;
	
	void Awake()
	{
		instance = FindObjectOfType<T>();
		if(instance == null)
		{
			instance = this as T;
		}
		else
		{
			Destroy(this);
		}
	}
	
	private void OnDestroy()
	{
		if(instance == this)
		{
			instance = null;
		}
	}
}