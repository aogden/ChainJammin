﻿using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	
	public Transform ResetTransform;
	public GameController.Team BallsTeam;
	
	private Rigidbody _rigidBody;
	private float _releaseCooldownTimer;

	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_releaseCooldownTimer > 0.0f)
		{
			_releaseCooldownTimer -= Time.deltaTime;
		}
	}
	
	public void OnRelease()
	{
		_rigidBody.isKinematic = false;
		_releaseCooldownTimer = 0.5f;
	}
	
	void FixedUpdate()
	{
		if(!_rigidBody.isKinematic && _releaseCooldownTimer <= 0.0f)
		{
			if(_rigidBody.velocity.sqrMagnitude < 1f)
			{
				Reset();
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name.Equals("Kill Floor"))
		{	
			Reset();
		}
		else if(other.gameObject.name.Equals("cup"))
		{
			BroadcastMessage("OnScore",BallsTeam,SendMessageOptions.DontRequireReceiver);
		}
	}
		
	void Reset()
	{
		transform.parent = ResetTransform;
		
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		
		_rigidBody.isKinematic = true;
	}
			
}
