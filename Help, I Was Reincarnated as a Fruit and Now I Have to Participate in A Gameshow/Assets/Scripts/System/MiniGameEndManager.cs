using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameEndManager : MonoBehaviour
{

    PersistentGlobalGameTracker tracker;


    public void OnMinigameRoundEnd() 
    {
        tracker = PersistentGlobalGameTracker.tracker;

        //Check to see if you have played a round for each team in the teamPlayerPairsForThisMinigame, if not count up the round by one and start the game scene again.
        if (tracker.currentMinigameRound< tracker.teamPlayerPairsForThisMinigame.Count) 
        {
            tracker.currentMinigameRound++;
            // Get the current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the current scene
            SceneManager.LoadScene(currentSceneIndex);
        } 
        //Check to see if you have played a round for each team, if you have: Go back to the intermediary scene
        else if (tracker.currentMinigameRound >= tracker.teamPlayerPairsForThisMinigame.Count) 
        {
            tracker.currentMinigameRound = 1;
            SceneManager.LoadScene("Intermediary Scene");


        }




    }
}
