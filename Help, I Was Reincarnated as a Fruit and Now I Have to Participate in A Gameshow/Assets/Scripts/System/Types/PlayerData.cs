using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerData
{
    //Variables that defnie the "PlayerData" type
    [SerializeField]
    public string playerName;
    [SerializeField]
    public int playerID;



    // Constructor to initialize the Minigame
    public PlayerData (string addPlayerName, int addPlayerID)
    {
        playerName = addPlayerName;
        playerID = addPlayerID;
      
    }
}
