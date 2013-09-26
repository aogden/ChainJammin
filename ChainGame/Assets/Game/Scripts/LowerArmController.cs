using UnityEngine;
using System.Collections;

public class LowerArmController : MonoBehaviour {
	
	public ChainJam.PLAYER Player;
	public GameObject Ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(ChainJam.GetButtonPressed(Player, ChainJam.BUTTON.A))
		{
			if(Ball != null && Ball.GetComponent<Rigidbody>().isKinematic)
			{
				Debug.Log("RELEASE");
				Ball.transform.parent = null;
//				Ball.GetComponent<Rigidbody>().AddForce(transform.right * GetComponent<Rigidbody>().angularVelocity.z * 0.6f);
				Ball.GetComponent<BallController>().OnRelease();
				Ball.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
			}
		}
		
	}
}
