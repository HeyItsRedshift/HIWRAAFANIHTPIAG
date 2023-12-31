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
    bool nameAqcuired = false;
    public PlayerButtonData myPlayerButtonData;
    public TeamButtonData myTeamButtonData;
    public TeamData myTeam;
    public PlayerData myPlayer;
    public string mytext ;
    // Start is called before the first frame update
    void Start()
    {


      

        

    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.name.Contains("PlayerName"))
        {
            myTeam = myPlayerButtonData.myTeam;
            myPlayer = myPlayerButtonData.myPlayer;
            if (!nameAqcuired)
            {
                if (myTeam.teamPlayers.Count > 0)
                {
                    while (!uniqueFruit)
                    {
                        int randomIndex = Random.Range(0, fruits.Length);
                        mytext = fruits[randomIndex];
                        uniqueFruit = true;
                        foreach (PlayerData player in myTeam.teamPlayers)
                        {
                            if (player.playerName == mytext) { uniqueFruit = false; print("reached3"); }
                        }
                    }
                    this.gameObject.GetComponent<TMP_Text>().text = mytext;

                    myPlayer.playerName = mytext;
                    nameAqcuired = true;
                }

            }
            this.gameObject.GetComponent<TMP_Text>().text = myPlayer.playerName;

        }

        if (this.gameObject.name.Contains("Teams"))
        {
            myTeam = myTeamButtonData.myTeam;
            this.gameObject.GetComponent<TMP_Text>().text = myTeam.teamName;

        }




    }
    
}
