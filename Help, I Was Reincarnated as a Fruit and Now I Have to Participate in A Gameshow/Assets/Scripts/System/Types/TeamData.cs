using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamData : MonoBehaviour
{
    //Variables that defnie the "TeamData" type
    public string teamName;
    public int teamID;
    public List<PlayerData> teamPlayers = new List<PlayerData> { };
    public int teamScore;



    // Constructor to initialize the Minigame
    public TeamData(string addteamName, int addteamID)
    {
        teamName = addteamName;
        teamID = addteamID;

    }
}
