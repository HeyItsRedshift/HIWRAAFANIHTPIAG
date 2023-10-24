using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonData : MonoBehaviour
{
    public int myPosition;
    public int myPlayerID;
    public int myTeamID;
    public TeamData myTeam;
    public PlayerData myPlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach (TeamData team in PersistentGlobalGameTracker.tracker.teamlist) { if (team.teamID == myTeamID) { myTeam = team; } } 
        foreach (PlayerData player in myTeam.teamPlayers) { if (player.playerID == myPlayerID) { myPlayer = player; } } 
    }
}
