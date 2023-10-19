using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Minigame
{
 
        public string minigameName;
        public bool selected;
        public int highScore;
        public string mVP;

        // Constructor to initialize the Minigame
        public Minigame(string name, bool isSelected, int score, string theMVP)
        {
            minigameName = name;
            selected = isSelected;
            highScore = score;
            mVP = theMVP;
        }
    
}
