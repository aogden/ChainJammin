﻿using UnityEngine;
using System.Collections;

public class UpperArmController : MonoBehaviour {
	
	public ChainJam.PLAYER Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(ChainJam.GetButtonPressed(Player, ChainJam.BUTTON.A))
		{
			GetComponent<Rigidbody>().AddTorque(0.0f,0.0f,500f);
		}
		if(ChainJam.GetButtonPressed(Player,ChainJam.BUTTON.B))
		{
			GetComponent<Rigidbody>().AddTorque(0.0f,0.0f,-500f);
		}
		
		
	}
}
