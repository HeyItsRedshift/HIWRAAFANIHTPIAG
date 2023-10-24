using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConnectNametoPGGT : MonoBehaviour
{
    private string[] fruits = {
        "Apple", "Banana", "Cherry", "Date", "Fig",
        "Grape", "Kiwi", "Lemon", "Mango", "Orange",
        "Peach", "Pear", "Quince", "Raspberry", "Strawberry",
        "Tomato", "Watermelon", "Blueberry", "Blackberry", "Pineapple",
        "Coconut", "Guava", "Pomegranate", "Plum", "Cranberry",
        "Avocado", "Papaya", "Lime", "Lychee", "Dragonfruit"
    };
    bool uniqueFruit=false;
    public PlayerButtonData myPlayerButtonData;
    public TeamData myTeam;
    public PlayerData myPlayer;
    public string mytext;
    // Start is called before the first frame update
    void Start()
    {

        while (!uniqueFruit)
        {
            int randomIndex = Random.Range(0, fruits.Length);
            mytext = fruits[randomIndex];
            uniqueFruit = true;
            foreach (PlayerData player in myTeam.teamPlayers) { if (player.playerName == mytext) { uniqueFruit = false; } }

        }
           
         

        

    }

    // Update is called once per frame
    void Update()
    {
        myTeam = myPlayerButtonData.myTeam;
        myPlayer = myPlayerButtonData.myPlayer;

        this.gameObject.GetComponent<TMP_Text>().text = mytext;
        PersistentGlobalGameTracker.tracker.teamlist.Find(team => team == myTeam).teamPlayers.Find(player => player == myPlayer).playerName = mytext;
       
    }
}
