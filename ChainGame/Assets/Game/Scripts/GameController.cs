using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject ArmPrefab;
	public Transform[] ArmContainers;
	
	public struct Team{
		public int index;
		public ChainJam.PLAYER lowerArm;
		public ChainJam.PLAYER upperArm;
	}
	
	Team[] _teams;
	GameObject[] _arms;
	

	// Use this for initialization
	void Start () {
		_teams = new Team[2];
		_teams[0] = new Team();
		_teams[0].index = 0;
		_teams[1] = new Team();
		_teams[0].index = 1;
		AssignTeams();
		CreateArms();
	}
	
	void AssignTeams()
	{
		bool[] teamPlacements = new bool[4];
		for(int i = 0; i < 4; i++)
		{
			bool placed = false;
			while(!placed)
			{
				int randomPlacementIndex = Random.Range(0,4);
				if(!teamPlacements[randomPlacementIndex])
				{
					teamPlacements[randomPlacementIndex] = true;
					if(randomPlacementIndex % 2 == 0)
					{
						_teams[randomPlacementIndex / 2].lowerArm = PlayerForIndex(i);
					}
					else
					{
						_teams[randomPlacementIndex / 2].upperArm = PlayerForIndex(i);
					}
					placed = true;
				}
			}
		}
		
	}
	
	void CreateArms()
	{
		_arms = new GameObject[2];
		for(int i = 0; i < 2; i++)
		{
			_arms[i] = GameObject.Instantiate(ArmPrefab) as GameObject;
			_arms[i].transform.parent = ArmContainers[i];
			_arms[i].transform.localPosition = Vector3.zero;
			_arms[i].transform.localRotation = Quaternion.identity;
			_arms[i].GetComponentInChildren<UpperArmController>().SetPlayer(_teams[i].upperArm);
			_arms[i].GetComponentInChildren<LowerArmController>().SetPlayer(_teams[i].lowerArm, GetTeamForPlayer(_teams[i].lowerArm));
		}
		
	}
	
	Team GetTeamForPlayer(ChainJam.PLAYER player)
	{
		for(int i = 0; i < 2; i++)
		{
			if(_teams[i].lowerArm == player || _teams[i].upperArm == player)
			{
				return _teams[i];
			}
		}
		
		return _teams[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static ChainJam.PLAYER PlayerForIndex(int index)
	{
		switch (index)
		{
		case 0:
			return ChainJam.PLAYER.PLAYER1;
		case 1:
			return ChainJam.PLAYER.PLAYER2;
		case 2:
			return ChainJam.PLAYER.PLAYER3;
		case 3:
			return ChainJam.PLAYER.PLAYER4;
		}
		
		return ChainJam.PLAYER.PLAYER1;
	}
	
	public static Material MaterialForPlayer(ChainJam.PLAYER player)
	{
		switch (player)
		{
		case ChainJam.PLAYER.PLAYER1:
			return Resources.Load("Materials/Player1") as Material;
		case ChainJam.PLAYER.PLAYER2:
			return Resources.Load("Materials/Player2") as Material;
		case ChainJam.PLAYER.PLAYER3:
			return Resources.Load("Materials/Player3") as Material;
		case ChainJam.PLAYER.PLAYER4:
			return Resources.Load("Materials/Player4") as Material;
		}
		return Resources.Load("Materials/Player1") as Material;
	}
}
