using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateControl : MonoBehaviour
{
    
    public GameObject deck;
    MemoryGameController memoryGameController = MemoryGameController.memoryGameController;



    public void GameStart() 
    {
        deck.SetActive(true);
        memoryGameController = MemoryGameController.memoryGameController;
        memoryGameController.AssignCardsToFruitCards();
        memoryGameController.FillFruitBasket();
        memoryGameController.AssignFruitsToFruitCards();
        memoryGameController.AssignCorrectImagesToCards();
        memoryGameController.TriggerSpawnAnimationsForAll();

    }
    
}
