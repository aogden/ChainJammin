using UnityEngine;
using System.Collections;

public class TeamScoreHUD : MonoBehaviour {
	
	public GUIText Text;
	public int Team;
	
	void Start()
	{
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
		foreach(GameObject ball in balls)
		{
			ball.GetComponent<BallController>().OnScore += OnScore;
		}
	}
	
	void OnScore(Transform hitSpot, GameController.Team team)
	{
		Debug.Log("SCORREEEE");
		if(team.index == Team)
		{
			Text.text = (int.Parse(Text.text) + 1).ToString();
		}
	}
			
}
