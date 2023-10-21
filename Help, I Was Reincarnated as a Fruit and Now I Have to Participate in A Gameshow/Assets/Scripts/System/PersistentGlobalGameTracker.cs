using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PersistentGlobalGameTracker : MonoBehaviour
{
    //This Script will be storing and handling all game information that is persistent throughout the scenes, like Scores, remaining rounds, MVPS, a list of data type minigame and each minigame, etc
    public static PersistentGlobalGameTracker tracker;
    [HideInInspector] public GameObject counterHolder;
    [SerializeField] bool test = false;
    [SerializeField] private int currentRound = 0;
    [SerializeField] private int numberOfRounds = 3;
    [SerializeField] private int scoreTeamA = 0;
    [SerializeField] private int scoreTeamB = 0;
    [SerializeField] private string nameTeamA = "Team 1";
    [SerializeField] private string nameTeamB = "Team 2";
    //Initialize minigames individually
   public Minigame minigame1 = new Minigame("MiniGame1", true, 0, "none");
    public Minigame minigame2 = new Minigame("MiniGame2", true, 0, "none");
    public Minigame minigame3 = new Minigame("MiniGame3", true, 0, "none");

    //Creates an empty list to add all the games later on for possible itterations
    public List<Minigame> allMinigames = new List<Minigame> { };

    //Creates an empty list to add the slected games later on for possible itterations, when the UpdateSelectedMinigames() Method is called
   [SerializeField] List<Minigame> selectedMinigames = new List<Minigame> { };

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

        foreach (string playerName in teamAPlayerNames)
        {
            Debug.Log(playerName);
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
}
