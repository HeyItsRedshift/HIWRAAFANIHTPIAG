using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    //Variables that defnie the "PlayerData" type
    public string playerName;
    public int playerID;



    // Constructor to initialize the Minigame
    public PlayerData (string addPlayerName, int addPlayerID)
    {
        playerName = addPlayerName;
        playerID = addPlayerID;
      
    }
}
