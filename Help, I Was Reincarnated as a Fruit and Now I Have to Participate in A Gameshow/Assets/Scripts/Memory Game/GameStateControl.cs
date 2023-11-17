using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateControl : MonoBehaviour
{
    
    public GameObject phase1Canvas;
    MemoryGameController memoryGameController = MemoryGameController.memoryGameController;

    public void prepeGame() { }

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

    }



    public void Phase2Start()
    {

        memoryGameController.StartTimerPhase2();
        memoryGameController.RollForSelectedFruit();
        memoryGameController.AssingButtonsToCards();
        memoryGameController.EnableGuessing();

    }



}
