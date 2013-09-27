using UnityEngine;
using System.Collections;

public class TeamScoreHUD : MonoBehaviour {
	
	public GUIText Text;
	public int Team;
	
	void Start()
	{
		StartCoroutine(delayedRegister());
	}
	
	void OnScore(Transform hitSpot, GameController.Team team)
	{
		Debug.Log("SCORREEEE by "+team.index+" score is "+team.score);
		if(team.index == Team)
		{
			Text.text = (int.Parse(Text.text) + 1).ToString();
		}
	}
	
	IEnumerator delayedRegister()
	{
		yield return new WaitForSeconds(0.5f);
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");
		foreach(GameObject ball in balls)
		{
			ball.GetComponent<BallController>().OnScore += OnScore;
		}
		Debug.Log("Register");
	}
}
