using UnityEngine;
using System.Collections;

public class TeamScoreHUD : MonoBehaviour {
	
	public GUIText Text;
	public int Team;
	
	void OnScore(GameController.Team team)
	{
		if(team.index == Team)
		{
			Text.text = (int.Parse(Text.text) + 1).ToString();
		}
	}
			
}
