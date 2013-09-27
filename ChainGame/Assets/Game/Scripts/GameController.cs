using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject ArmPrefab;
	public Transform[] ArmContainers;
	
	struct Team{
		public ChainJam.PLAYER lowerArm;
		public ChainJam.PLAYER upperArm;
	}
	
	Team[] _teams;
	GameObject[] _arms;
	

	// Use this for initialization
	void Start () {
		_teams = new Team[2];
		_teams[0] = new Team();
		_teams[1] = new Team();
		AssignTeams();
		CreateArms();
	}
	
	void AssignTeams()
	{
		bool[] teamPlacements = new bool[4];
		for(int i = (int)ChainJam.PLAYER.PLAYER1; i <= (int)ChainJam.PLAYER.PLAYER4; i++)
		{
			while(true)
			{
				int randomPlacementIndex = Random.Range(0,4);
				Debug.Log("Trying to get team assignment at "+randomPlacementIndex);
				if(!teamPlacements[randomPlacementIndex])
				{
					teamPlacements[randomPlacementIndex] = true;
					Team assignedTeam = _teams[randomPlacementIndex / 2];
					if(randomPlacementIndex % 2 == 0)
					{
						assignedTeam.lowerArm = (ChainJam.PLAYER)i;
					}
					else
					{
						assignedTeam.upperArm = (ChainJam.PLAYER)i;
					}
					Debug.Log("Found team assignment at "+randomPlacementIndex);
					break;
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
			_arms[i].GetComponentInChildren<UpperArmController>().Player = _teams[i].upperArm;
			_arms[i].GetComponentInChildren<LowerArmController>().Player = _teams[i].lowerArm;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
