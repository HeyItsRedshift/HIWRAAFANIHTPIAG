using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermediaryConductor : MonoBehaviour
{
    PersistentGlobalGameTracker tracker;
    public MinigameAndTeamRoller roller;
    void Awake()
    {
     tracker = PersistentGlobalGameTracker.tracker;
        RoundCheck();
    }

   public void RoundCheck() 
    {

        if (tracker.currentRound <= tracker.numberOfRounds)
        {
            tracker.currentMinigameRound = 1;
            roller.RollEverything();
            roller.AssignFirstTeamandPlayers();
            tracker.currentRound++;

            //Play animations with timer

          //The name of the minigames should match tha name of the scenes, that way it loads the game scene automatically
          SceneManager.LoadScene(tracker.currentMinigame.minigameName);


        }
        else 
        {
            SceneManager.LoadScene("End Game Screen");


        }

    }


}
