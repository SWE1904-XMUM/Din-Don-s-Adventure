using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
	private CinemachineVirtualCamera cvCam;
	private Transform playerTransform;
    
    void Start()
    {
		cvCam = GetComponent<CinemachineVirtualCamera>();
		
		//find player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}

    void Update()
    {
		//set the follow object to player
        cvCam.m_Follow = playerTransform;
    }
}
