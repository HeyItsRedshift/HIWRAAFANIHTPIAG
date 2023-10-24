using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PersistentGlobalGameTracker : MonoBehaviour
{    
    //This Script will be storing and handling all game information that is persistent throughout the scenes, like Scores, remaining rounds, MVPS, a list of data type minigame and each minigame, etc

    #region  System
    public static PersistentGlobalGameTracker tracker;
    public HashSet<int> playerIDSList = new HashSet<int> { };
    public HashSet<int> teamIDSList = new HashSet<int> { };
    [SerializeField] private int currentRound = 0;
    [SerializeField] private int numberOfRounds = 3;
    [HideInInspector] public GameObject counterHolder;
    #endregion


    #region  Teams
    [SerializeField] public List<TeamData> teamlist = new List<TeamData> { };
                     public TeamData team1;
                     public TeamData team2;
    public PlayerData player1A;
    public PlayerData player2A;


    #endregion


    #region Minigames Related Variables 
    //Initialize minigames individually
    public Minigame minigame1 = new Minigame("MiniGame1", true, 0, "none");
    public Minigame minigame2 = new Minigame("MiniGame2", true, 0, "none");
    public Minigame minigame3 = new Minigame("MiniGame3", true, 0, "none");
    //Creates an empty list that will hold all minigames.
    public List<Minigame> allMinigames = new List<Minigame> { };
    //Creates an empty list to add the slected games later on for possible itterations, when the UpdateSelectedMinigames() Method is called
    [SerializeField] List<Minigame> selectedMinigames = new List<Minigame> { };
    #endregion


    private void Awake()
    {
        player1A = new PlayerData("me",1);
        team1 = new TeamData("team 1", 1);
        team1.teamPlayers.Add(player1A);
        team2 = new TeamData("team 1", 2);
        teamlist.Add(team1);
        tracker = this.gameObject.GetComponent<PersistentGlobalGameTracker>();
        //Keeps the gameobject holding this script active between scenes
        DontDestroyOnLoad(this.gameObject);
        allMinigames.Add(minigame1);
        allMinigames.Add(minigame2);
        allMinigames.Add(minigame3);
        foreach (Minigame minigame in allMinigames)
        {
            selectedMinigames.Add(minigame);

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (counterHolder != null)
        {
            counterHolder.GetComponent<TextMeshProUGUI>().text = numberOfRounds.ToString();
        }

      
        if (selectedMinigames.Count == 0)
        {
            foreach (Minigame minigame in allMinigames)
            {
                selectedMinigames.Add(minigame);

            }
        }

    }

    public void UpdateSelectedMinigames()
    {
        selectedMinigames.Clear();

        foreach (Minigame minigame in allMinigames)
        {
            if (minigame.selected && !selectedMinigames.Contains(minigame))
            {
                selectedMinigames.Add(minigame);
            }
        }
    }

    public void changeName(string newChange, int indexOfNameToBeChanged)
    { 
    
    }

    public void IncreaseRounds()
    {
       
            numberOfRounds++;
       
    }
    public void DecreaseRounds()
    {
        if (numberOfRounds > 1)
        {
            numberOfRounds--;
        }
    }

    public int CreateNewPlayerOnTeam(TeamData team) 
    {
        int playerID ;

        do
        {
            playerID = UnityEngine.Random.Range(00001, 99999);
        }
        while (!playerIDSList.Add(playerID)); // Checks if the number can be added to the HashSet, if it can, it will add the number to the HashSet (with the IDS), return true, and end the while loop

        PlayerData newplayer = new PlayerData("New Player", playerID);
        team.teamPlayers.Add(newplayer);

        return playerID;

    }

    public int CreateNewTeam()
    {
        int teamID;

        do
        {
            teamID = UnityEngine.Random.Range(00001, 99999);
        }
        while (!teamIDSList.Add(teamID)); // Checks if the number can be added to the HashSet, if it can, it will add the number to the HashSet (with the IDS), return true, and end the while loop

        TeamData newTeam = new TeamData("New Team", teamID);
        teamlist.Add(newTeam);

        return teamID;

    }
}
