using UnityEngine;
using System.Collections;

public class LowerArmController : MonoBehaviour {
	
	public GameObject Ball;
	
	public ChainJam.PLAYER Player;

	// Use this for initialization
	void Start () {
	
	}
	
	public void SetPlayer(ChainJam.PLAYER player, GameController.Team team)
	{
		Player = player;
		GetComponent<MeshRenderer>().sharedMaterial = GameController.MaterialForPlayer(player);
		Ball.GetComponent<BallController>().BallsTeam = team;
		transform.FindChild("lowerArt").GetComponent<MeshRenderer>().material.SetColor("_Color",GameController.MaterialForPlayer(player));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float directionModifier = transform.position.x > 0 ? -1f : 1f;
		if(ChainJam.GetButtonPressed(Player, ChainJam.BUTTON.A))
		{
			GetComponent<Rigidbody>().AddTorque(0.0f,0.0f,directionModifier*-650f);
		}
		else if(ChainJam.GetButtonJustReleased(Player,ChainJam.BUTTON.A))
		{
			if(Ball != null && Ball.GetComponent<Rigidbody>().isKinematic)
			{
				Debug.Log("RELEASE");
				Ball.transform.parent = null;
				Ball.GetComponent<Rigidbody>().AddForce(transform.right * GetComponent<Rigidbody>().angularVelocity.z * 0.6f);
				Ball.GetComponent<BallController>().OnRelease();
				Ball.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
			}
		}
	}
}
