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
    public TeamData myTeam;
    public PlayerData myPlayer;
    public string mytext ;
    // Start is called before the first frame update
    void Start()
    {


        myTeam = myPlayerButtonData.myTeam;
        myPlayer = myPlayerButtonData.myPlayer;
        
       
      

        

    }

    // Update is called once per frame
    void Update()
    {
        if (!nameAqcuired) {
            if (myTeam.teamPlayers.Count > 0)
            {
                while (!uniqueFruit)
                {
                    int randomIndex = Random.Range(0, fruits.Length);
                    mytext = fruits[randomIndex];
                    uniqueFruit = true;
                    print("reached leng" + myTeam.teamPlayers.Count);
                    foreach (PlayerData player in myTeam.teamPlayers)
                    {
                        print("reached2");
                        if (player.playerName == mytext) { uniqueFruit = false; print("reached3"); }
                        print("reached4");
                    }
                    print("reached5");
                }
            }
        }
        myTeam = myPlayerButtonData.myTeam;
        myPlayer = myPlayerButtonData.myPlayer;

        this.gameObject.GetComponent<TMP_Text>().text = mytext;

        myPlayer.playerName = mytext;

        print(" leng" + myTeam.teamPlayers.Count);

    }
}
