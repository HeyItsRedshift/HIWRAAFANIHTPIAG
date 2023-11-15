using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;



public class PersistentGlobalGameTracker : MonoBehaviour
{
    //This Script will be storing and handling all game information that is persistent throughout the scenes, like Scores, remaining rounds, MVPS, a list of data type minigame and each minigame, etc
    #region Public Variables
    public List<PlayerData> CurrentPlayers;
    public Minigame currentMinigame;
    public TeamData CurrentTeam;
    [SerializeField] public int currentRound = 0;
    [SerializeField] public int numberOfRounds = 3;
    public int currentMinigameRound = 1;

   public List<Tuple<TeamData, List<PlayerData>>> teamPlayerPairsForThisMinigame = new List<Tuple<TeamData, List<PlayerData>>>();

    #endregion

    #region References
    [HideInInspector] public GameObject counterHolder;
    public static PersistentGlobalGameTracker tracker;
    #endregion

    #region  System

    public HashSet<int> playerIDSList = new HashSet<int> { };
    public HashSet<int> teamIDSList = new HashSet<int> { };

    
    #endregion


    #region  TeamsPremade
    [SerializeField] public List<TeamData> teamlist = new List<TeamData> { };
                     public TeamData team1;
                     public TeamData team2;

    [HideInInspector] public PlayerData player1A;
    [HideInInspector] public PlayerData player2A;
    [HideInInspector] public PlayerData player1B;
    [HideInInspector] public PlayerData player2B;



    #endregion


    #region Minigames Related Variables 
    //Initialize minigames individually
     public Minigame minigame1 = new Minigame("Stems Up", true, 0, "none");
    public Minigame minigame2 = new Minigame("Memory", true, 0, "none");
     public Minigame minigame3 = new Minigame("Rhythm", true, 0, "none");
    //Creates an empty list that will hold all minigames.
    public List<Minigame> allMinigames = new List<Minigame> { };
    //Creates an empty list to add the slected games later on for possible itterations, when the UpdateSelectedMinigames() Method is called
    [SerializeField] List<Minigame> selectedMinigames = new List<Minigame> { };
    #endregion


    private void Awake()
    {
        player1B = new PlayerData("Banana", 3);
        player2B = new PlayerData("Strawberry", 4);
        player1A = new PlayerData("Orange",1);
        player2A = new PlayerData("Apple", 2);
        team1 = new TeamData("team 1", 1);
        team2 = new TeamData("team 2", 2);
        team2.teamPlayers.Add(player1B);

        team2.teamPlayers.Add(player2B);
        team1.teamPlayers.Add(player1A);
        team1.teamPlayers.Add(player2A);

        teamlist.Add(team1);
        teamlist.Add(team2);
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

    public TeamData findMyTeam(int myTeamID)
    {
        TeamData myTeam = new TeamData("",0);
       
        if (PersistentGlobalGameTracker.tracker.teamlist != null)
        {
            foreach (TeamData team in PersistentGlobalGameTracker.tracker.teamlist)
            {

                if (team.teamID == myTeamID) { myTeam = team; }

            }
            // myTeam = PersistentGlobalGameTracker.tracker.teamlist.Find(team => team.teamID == myTeamID);
        }

        return myTeam;
    }
    public PlayerData findMyPlayer(int myPlayerID, TeamData myTeam)
    {
        PlayerData myPlayer = new PlayerData("", 0);

        if (PersistentGlobalGameTracker.tracker.teamlist != null)
        {
            foreach (PlayerData player in myTeam.teamPlayers)
            {

                if (player.playerID == myPlayerID) { myPlayer = player; }

            }
            // myTeam = PersistentGlobalGameTracker.tracker.teamlist.Find(team => team.teamID == myTeamID);
        }

        return myPlayer;
    }
}
