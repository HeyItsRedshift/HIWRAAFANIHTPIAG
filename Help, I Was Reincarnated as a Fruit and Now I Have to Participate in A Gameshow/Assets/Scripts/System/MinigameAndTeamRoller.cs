using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MinigameAndTeamRoller : MonoBehaviour
{
    Minigame currentMinigame;
    PersistentGlobalGameTracker tracker;
    //Itterate through this to get which players and from which teamyou are playing right now.
    List<Tuple<TeamData, List<PlayerData>>> teamPlayerPairsForThisMinigame = new List<Tuple<TeamData, List<PlayerData>>>();
    //Itterate through this and empty it out. When empty, refill. This gets all the players from each team on the teamlist from PGGT. Then on roll it feeds the players with their team to the teamPlayerPairsForThisMinigame, when you feed the player, remove it from here.
    public List<Tuple<TeamData, List<PlayerData>>> playerPools = new List<Tuple<TeamData, List<PlayerData>>>();

    void Start()
    {
        tracker = PersistentGlobalGameTracker.tracker;
    }

    void Update()
    {
        
    }

    void InitializePlayerPools() 
    {
        foreach (TeamData team in tracker.teamlist) 
        {

            // Create a new Tuple for each team
            Tuple<TeamData, List<PlayerData>> teamPlayerPair = Tuple.Create(team, new List<PlayerData>());

            foreach (PlayerData player in team.teamPlayers) { teamPlayerPair.Item2.Add(player); }

            // Add the tuple to the list
            playerPools.Add(teamPlayerPair);


        }

    }

   public void RollEverything()
    {
        tracker = PersistentGlobalGameTracker.tracker;

        InitializePlayerPools();

        int CurrentMinigameIndex = UnityEngine.Random.Range(0,tracker.allMinigames.Count);
        currentMinigame = tracker.allMinigames[CurrentMinigameIndex];
        int optPlayerNum = currentMinigame.maxPlayers;

        foreach (Tuple<TeamData, List<PlayerData>> pair in playerPools)
        {
            Tuple<TeamData, List<PlayerData>> teamPlayerPair = Tuple.Create(pair.Item1, new List<PlayerData>());
            if (optPlayerNum <= pair.Item1.teamPlayers.Count) 
            {
                for (int i = 0; i < optPlayerNum; i++)
                {
                    //Refill players if the pool is emptied out
                    if (pair.Item1.teamPlayers == null) { foreach (PlayerData player in pair.Item1.teamPlayers) { teamPlayerPair.Item2.Add(player); } }
                    //Remove players from the pool and add them in the Tuple that will be added in the teamPlayerPairsForThisMinigame
                    else
                    {
                        int indexOfRandPlayer = UnityEngine.Random.Range(0, pair.Item1.teamPlayers.Count);
                        teamPlayerPair.Item2.Add(pair.Item1.teamPlayers[indexOfRandPlayer]);
                        pair.Item2.Remove(pair.Item1.teamPlayers[indexOfRandPlayer]);
                    }
                 
                }
            }
            teamPlayerPairsForThisMinigame.Add(teamPlayerPair);
        }
    }


    public void Tester(List<Tuple<TeamData, List<PlayerData>>> playerPools) 
    { 
    
         foreach(Tuple<TeamData, List<PlayerData>> testc in playerPools)
        


    }

}
