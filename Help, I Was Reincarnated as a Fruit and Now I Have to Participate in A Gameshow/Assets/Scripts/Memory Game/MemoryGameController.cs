using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController : MonoBehaviour
{
   public static MemoryGameController memoryGameController;
    public List<Sprite> spriteList;
    public List<GameObject> cardObjects;
    public List<FruitCardData> fruitCards;
    public List<string> fruitBasket;
    private List<string> fruitTypes = new List<string> {"Banana","Tomato","Watermelon","Cherries","Orange","Apple","Grapes","Strawberry"};
    string correctButton;
    // Start is called before the first frame update
    void Start()
    {
        memoryGameController = this.gameObject.GetComponent<MemoryGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerSpawnAnimationsForAll() 
    {
        foreach (FruitCardData fruitCard in fruitCards) 
        {
          fruitCard.card.transform.Find("Image").GetComponent<Animator>().SetTrigger("Spawn");
        }
    }
    public void AssignCorrectImagesToCards()
    
    {
       
        foreach (FruitCardData fruitCard in fruitCards)
        {
            string fruit = fruitCard.fruit;
           Image cardImage = fruitCard.card.transform.Find("Image").GetComponent<Image>();
            switch (fruit)
            {
                case "Banana":
                    cardImage.sprite = spriteList[0];
                    break;
                case "Tomato":
                    cardImage.sprite = spriteList[1];
                    break;
                case "Watermelon":
                    cardImage.sprite = spriteList[2];
                    break;
                case "Cherries":
                    cardImage.sprite = spriteList[3];
                    break;
                case "Orange":
                    cardImage.sprite = spriteList[4];
                    break;
                case "Apple":
                    cardImage.sprite = spriteList[5];
                    break;
                case "Grapes":
                    cardImage.sprite = spriteList[6];
                    break;
                case "Strawberry":
                    cardImage.sprite = spriteList[7];
                    break;
                default:
                    break;
            }

        }
       


    }

   public void FillFruitBasket() 
    {
        List<string> options = fruitTypes;
        List<string> optionsToEmpty = new List<string>{ } ;
        foreach (string fruit in options) 
        { optionsToEmpty.Add(fruit); }

        for(int i = 0; i < 6; i++)
        {
         int x =   Random.Range(0,optionsToEmpty.Count);
            fruitBasket.Add(optionsToEmpty[x]);
            fruitBasket.Add(optionsToEmpty[x]);
            fruitBasket.Add(optionsToEmpty[x]);
            optionsToEmpty.Remove(optionsToEmpty[x]);
      
        }


    }
    public void AssignFruitsToFruitCards() 
    {
        for (int i = 0 ; i < fruitCards.Count; i++)
        {

            int x = Random.Range(0, fruitBasket.Count);
            print(fruitBasket[x]);
            fruitCards[i].fruit = fruitBasket[x];
            fruitBasket.Remove(fruitBasket[x]);
        }

    }

    public void AssignCardsToFruitCards( ) 
    {
        List<GameObject> cards = cardObjects;
        List<FruitCardData> fruitCardstoret = new List<FruitCardData>();
        foreach (GameObject card in cards)
        {
            FruitCardData fruitCard = new FruitCardData(card);
            fruitCardstoret.Add(fruitCard);
        
        }
        fruitCards = fruitCardstoret;

    }
}
