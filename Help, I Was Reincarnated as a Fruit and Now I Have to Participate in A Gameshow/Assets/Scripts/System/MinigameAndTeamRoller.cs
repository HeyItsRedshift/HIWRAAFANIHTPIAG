using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MinigameAndTeamRoller : MonoBehaviour
{
    PersistentGlobalGameTracker tracker;
    //Itterate through this to get which players and from which teamyou are playing right now.
    //Itterate through this and empty it out. When empty, refill. This gets all the players from each team on the teamlist from PGGT. Then on roll it feeds the players with their team to the teamPlayerPairsForThisMinigame, when you feed the player, remove it from here.
    public List<Tuple<TeamData, List<PlayerData>>> playerPools = new List<Tuple<TeamData, List<PlayerData>>>();

    void Start()
    {
        tracker = PersistentGlobalGameTracker.tracker;
    }

    void InitializePlayerPools() 
    {

        if (playerPools.Count == 0)
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
       

    }

   public void RollEverything()
    {
        tracker = PersistentGlobalGameTracker.tracker;
             tracker.teamPlayerPairsForThisMinigame.Clear();

        InitializePlayerPools();

        int CurrentMinigameIndex = UnityEngine.Random.Range(0,tracker.allMinigames.Count);
        tracker.currentMinigame = tracker.allMinigames[CurrentMinigameIndex];
        int optPlayerNum = tracker.currentMinigame.maxPlayers;

        foreach (Tuple<TeamData, List<PlayerData>> pair in playerPools)
        {
            Tuple<TeamData, List<PlayerData>> teamPlayerPair = Tuple.Create(pair.Item1, new List<PlayerData>());

            if (optPlayerNum <= pair.Item1.teamPlayers.Count) 
            {
                for (int i = 0; i < optPlayerNum; i++)
                {
                    //Refill players if the pool is emptied out
                    if (pair.Item2.Count == 0)
                    {
                        foreach (PlayerData player in pair.Item1.teamPlayers) { pair.Item2.Add(player); } 
                    }
                    //Remove players from the pool and add them in the Tuple that will be added in the teamPlayerPairsForThisMinigame
                   
                    {
                        int indexOfRandPlayer = UnityEngine.Random.Range(0, pair.Item2.Count);

                        while (teamPlayerPair.Item2.Contains(pair.Item2[indexOfRandPlayer]))
                        {
                            indexOfRandPlayer = UnityEngine.Random.Range(0, pair.Item2.Count);
                        }

                        teamPlayerPair.Item2.Add(pair.Item2[indexOfRandPlayer]);
                        pair.Item2.Remove(pair.Item2[indexOfRandPlayer]);
                    }
                }
                tracker.teamPlayerPairsForThisMinigame.Add(teamPlayerPair);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    //Refill players if the pool is emptied out
                    if (pair.Item2.Count == 0)
                    {
                        foreach (PlayerData player in pair.Item1.teamPlayers) { pair.Item2.Add(player); }
                    }
                    //Remove players from the pool and add them in the Tuple that will be added in the teamPlayerPairsForThisMinigame
                    else
                    {
                        int indexOfRandPlayer = UnityEngine.Random.Range(0, pair.Item2.Count);
                        teamPlayerPair.Item2.Add(pair.Item2[indexOfRandPlayer]);
                        pair.Item2.Remove(pair.Item2[indexOfRandPlayer]);
                    }
                }
                tracker.teamPlayerPairsForThisMinigame.Add(teamPlayerPair);
            }
        }
        print(playerPools.Count);

    }

    public void AssignFirstTeamandPlayers() 
    {
      
        tracker.CurrentPlayers.Clear();

        //Adds the team to the current team list.
        tracker.CurrentTeam = tracker.teamPlayerPairsForThisMinigame[0].Item1;
       foreach (PlayerData player in tracker.teamPlayerPairsForThisMinigame[0].Item2)
        { tracker.CurrentPlayers.Add(player); }
    
    
    }

    public void Tester(List<Tuple<TeamData, List<PlayerData>>> playerP) 
    {

        foreach (Tuple<TeamData, List<PlayerData>> testc in playerP)
        {

            print(testc.Item1.teamName);
            foreach (PlayerData player in testc.Item2) 
            {
                print(player.playerName);
            }
        }
        


    }

}
