using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateControl : MonoBehaviour
{
    public GameObject phase1Canvas;
    public GameObject phase1TextHolder;
   public GameObject phase2TextHolder;
    public GameObject phase3TextHolder;
    public GameObject phase4TextHolder;
    public GameObject winTextHolder;
    public GameObject loseTextHolder;
    public GameObject ScoreScreenPrompt;
    public GameObject textGameScreen;
    public GameObject scoreGameScreen;
    PersistentGlobalGameTracker tracker;

    MemoryGameController memoryGameController = MemoryGameController.memoryGameController;
    GameStateControl methodsToAdd;
    private void Start()
    {
        tracker = PersistentGlobalGameTracker.tracker;
        TypwriterAndSlideShow.delegeteAtTheEnd += GameStart;
    }
   

    public void prepPhase2() { memoryGameController.MemorizationFinished(); phase3TextHolder.SetActive(true);
        phase2TextHolder.SetActive(false); TypwriterAndSlideShow.delegeteAtTheEnd -= prepPhase2; TypwriterAndSlideShow.delegeteAtTheEnd += Phase2Start;
    }

    public void GameStart() 
    {
        phase1Canvas.SetActive(true);
        memoryGameController = MemoryGameController.memoryGameController;
        memoryGameController.AssignCardsToFruitCards();
        memoryGameController.FillFruitBasket();
        memoryGameController.AssignFruitsToFruitCards();
        memoryGameController.AssignCorrectImagesToCards();
        memoryGameController.TriggerSpawnAnimationsForAll();
        memoryGameController.StartTimerPhase1();
        TypwriterAndSlideShow.delegeteAtTheEnd -= GameStart;
        TypwriterAndSlideShow.delegeteAtTheEnd += prepPhase2;
        phase2TextHolder.SetActive(true);
        phase1TextHolder.SetActive(false);
    }



    public void Phase2Start()
    {
        phase4TextHolder.SetActive(true);
        phase3TextHolder.SetActive(false);
        memoryGameController.StartTimerPhase2();
        memoryGameController.RollForSelectedFruit();
        memoryGameController.AssingButtonsToCards();
        memoryGameController.EnableGuessing();
        TypwriterAndSlideShow.delegeteAtTheEnd -= Phase2Start;

    }

    public void Win() { memoryGameController.RevealAllCards(); TypwriterAndSlideShow.delegeteAtTheEnd -= Win; winTextHolder.SetActive(false); ScoreScreenPrompt.SetActive(true); TypwriterAndSlideShow.delegeteAtTheEnd += AfterChoice; }
    public void Lose() { memoryGameController.RevealAllCards(); TypwriterAndSlideShow.delegeteAtTheEnd -= Lose;   loseTextHolder.SetActive(false); ScoreScreenPrompt.SetActive(true); TypwriterAndSlideShow.delegeteAtTheEnd += AfterChoice; }

    public void AfterChoice() { TypwriterAndSlideShow.delegeteAtTheEnd -= AfterChoice; TypwriterAndSlideShow.delegeteAtTheEnd += OpenScoreScreen; scoreGameScreen.SetActive(true); textGameScreen.SetActive(false); phase1Canvas.SetActive(false);  }

    public void OpenScoreScreen() { TypwriterAndSlideShow.delegeteAtTheEnd -= OpenScoreScreen; tracker.AfterScoreScreen();  }


}
