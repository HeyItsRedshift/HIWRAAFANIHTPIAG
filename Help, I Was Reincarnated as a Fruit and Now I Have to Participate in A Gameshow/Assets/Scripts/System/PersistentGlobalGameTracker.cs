using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PersistentGlobalGameTracker: MonoBehaviour
{
    //This Script will be storing and handling all game information that is persistent throughout the scenes, like Scores, remaining rounds, MVPS, a list of data type minigame and each minigame, etc
    public static PersistentGlobalGameTracker persistentGlobalGameTracker;
    [SerializeField] bool test=false;
    [SerializeField] private int currentRound = 0;
    [SerializeField] private int numberOfRounds = 0;
    [SerializeField] private int scoreTeamA = 0;
    [SerializeField] private int scoreTeamB = 0;
    [SerializeField] private string nameTeamA = "Team 1";
    [SerializeField] private string nameTeamB = "Team 2";
    //Initialize minigames individually
    Minigame minigame1 = new Minigame("MiniGame1", true, 0, "none");
    Minigame minigame2 = new Minigame("MiniGame2", true, 0, "none");
    Minigame minigame3 = new Minigame("MiniGame3", true, 0, "none");

    //Creates an empty list to add all the games later on for possible itterations
    public List<Minigame> allMinigames = new List<Minigame> { };

    //Creates an empty list to add the slected games later on for possible itterations, when the UpdateSelectedMinigames() Method is called
   List<Minigame> selectedMinigames = new List<Minigame> { };

    //Playernames list to be used when adding players and for itterations. (Add players by using " teamAPlayerNames.Add("name");";"
    
    /*  Itterate through the list with this:
     
       foreach (string playerName in teamAPlayerNames)
            {
                Debug.Log(playerName);
            } 
    */

   public List<string> teamAPlayerNames = new List<string> { };
   public List<string> teamBPlayerNames = new List<string> { };


    private void Awake()
    {
        persistentGlobalGameTracker = this.gameObject.GetComponent<PersistentGlobalGameTracker>();
        //Keeps the gameobject holding this script active between scenes
        DontDestroyOnLoad(this.gameObject);
        allMinigames.Add(minigame1);
        allMinigames.Add(minigame2);
        allMinigames.Add(minigame3);
    }


    // Update is called once per frame
    void Update()
    {
     
            foreach (string playerName in teamAPlayerNames)
            {
                Debug.Log(playerName);
            }
       
    }

    public  void UpdateSelectedMinigames() 
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
}
