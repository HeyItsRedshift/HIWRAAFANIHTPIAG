using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MemoryGameController : MonoBehaviour
{
    public static MemoryGameController memoryGameController;
    public bool phase1StartTimer = false;
    bool phase2StartTimer = false;
    bool guessingIsEnabled = false;
    bool guessHasBeenMade = false;
    public int totalPoints;
    private int pointsModifierP1=1;
    private int pointsModifierP2;
    public float timerPhase1;
    private float timerPhase1Max = 30;
    public float timerPhase2;
    private float timerPhase2Max = 30;
    public List<Sprite> spriteList;
    public List<Sprite> buttonSpriteList;
    public List<GameObject> cardObjects;
    public List<FruitCardData> fruitCards;
    public List<string> fruitBasket;
    public List<string> selectedFruitsList;
    public string fruitTarget;
    public string correctButton;
    private List<string> buttons = new List<string> { "Left", "Right", "Up", "Down", "A", "B", "X", "Y" };
    private List<string> fruitTypes = new List<string> { "Banana", "Tomato", "Watermelon", "Cherries", "Orange", "Apple", "Grapes", "Strawberry" };
    // Start is called before the first frame update
    void Start()
    {
        timerPhase1 = timerPhase1Max;
        timerPhase2 = timerPhase2Max;

        memoryGameController = this.gameObject.GetComponent<MemoryGameController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (guessingIsEnabled) { Guess(); }
        if (phase1StartTimer) { timerPhase1 -= Time.deltaTime; }
        if (phase2StartTimer && timerPhase2>0.01f) { timerPhase2 -= Time.deltaTime; }
    }

    public void MemorizationFinished() { StopTimerPhase1(); TriggerFlipAnimationForAll(); }
    public void StopTimerPhase2()
    {
        phase2StartTimer = false;
    }
    public void StopTimerPhase1()
    {
        phase1StartTimer = false;
    }
    public void StartTimerPhase2()
    {
        phase2StartTimer = true;
    }

    public void StartTimerPhase1()
    {
        phase1StartTimer = true;
    }
    public void TriggerSpawnAnimationsForAll()
    {
        float i = 0;
        foreach (FruitCardData fruitCard in fruitCards)
        {

            fruitCard.card.transform.Find("Image").GetComponent<TriggerFruitSpawnAnimation>().timerDelay += i;
            fruitCard.card.transform.Find("Image").GetComponent<TriggerFruitSpawnAnimation>().timeToSpawn = true;
            i += 0.01f;

        }
    }

    public void TriggerFlipAnimationForAll()
    {
        float i = 0;
        foreach (FruitCardData fruitCard in fruitCards)
        {

            fruitCard.card.transform.Find("Image").GetComponent<TriggerCardFlipAnimation>().timerDelay += i;
            fruitCard.card.transform.Find("Image").GetComponent<TriggerCardFlipAnimation>().timeToSpawn = true;
            i += 0.01f;

        }
    }


    public void FlipCards() {
        foreach (FruitCardData fruitCard in fruitCards)
        {
            Image cardImage = fruitCard.card.transform.Find("Image").GetComponent<Image>();
            cardImage.sprite = spriteList[8];
        }
    }

    public void RollForSelectedFruit()
    {
        int i = Random.Range(0, selectedFruitsList.Count);
        fruitTarget = selectedFruitsList[i];

    } 



    public void AssingButtonsToCards()
    {// { "Left","Right","Up","Down","A","B","X","Y" };
        int fruitIndex = Random.Range(0, fruitCards.Count);
        int i = Random.Range(0, buttons.Count);
        correctButton = buttons[i];
        buttons.Remove(buttons[i]);
        string buttonRef = correctButton;
        while (fruitCards[fruitIndex].fruit != fruitTarget)
        { fruitIndex = Random.Range(0, fruitCards.Count);  ;
        }
        fruitCards[fruitIndex].button = correctButton;
        Image buttonImage = fruitCards[fruitIndex].card.transform.Find("Button").GetComponent<Image>();
        buttonImage.enabled = true;

        switch (buttonRef)
        {
            case "Left":
                buttonImage.sprite = buttonSpriteList[0];
                break;
            case "Right":
                buttonImage.sprite = buttonSpriteList[1];
                break;
            case "Up":
                buttonImage.sprite = buttonSpriteList[2];
                break;
            case "Down":
                buttonImage.sprite = buttonSpriteList[3];
                break;
            case "A":
                buttonImage.sprite = buttonSpriteList[4];
                break;
            case "B":
                buttonImage.sprite = buttonSpriteList[5];
                break;
            case "X":
                buttonImage.sprite = buttonSpriteList[6];
                break;
            case "Y":
                buttonImage.sprite = buttonSpriteList[7];
                break;
            default:
                break;
        }
        
        foreach (string button in buttons) 
        { int attempts = 0;
            fruitIndex = Random.Range(0, fruitCards.Count);
            ;
            while (fruitCards[fruitIndex].fruit == fruitTarget || fruitCards[fruitIndex].card.transform.Find("Button").GetComponent<Image>().IsActive() )
            { fruitIndex = Random.Range(0, fruitCards.Count); attempts++;

                if (attempts > 100000) { break; }
            }
            buttonRef = button;
            buttonImage = fruitCards[fruitIndex].card.transform.Find("Button").GetComponent<Image>();
            switch (buttonRef)
            {
                case "Left":
                    buttonImage.sprite = buttonSpriteList[0];
                    fruitCards[fruitIndex].button = "Left";
                    break;
                case "Right":
                    buttonImage.sprite = buttonSpriteList[1];
                    fruitCards[fruitIndex].button = "Right";
                    break;
                case "Up":
                    buttonImage.sprite = buttonSpriteList[2];
                    fruitCards[fruitIndex].button = "Up";
                    break;
                case "Down":
                    buttonImage.sprite = buttonSpriteList[3];
                    fruitCards[fruitIndex].button = "Down";
                    break;
                case "A":
                    buttonImage.sprite = buttonSpriteList[4];
                    fruitCards[fruitIndex].button = "A";
                    break;
                case "B":
                    buttonImage.sprite = buttonSpriteList[5];
                    fruitCards[fruitIndex].button = "B";
                    break;
                case "X":
                    buttonImage.sprite = buttonSpriteList[6];
                    fruitCards[fruitIndex].button = "X";
                    break;
                case "Y":
                    buttonImage.sprite = buttonSpriteList[7];
                    fruitCards[fruitIndex].button = "Y";
                    break;
                default:
                    break;
            }
            buttonImage.enabled = true;


        }
        




    }

    public void EnableGuessing() { guessingIsEnabled = true; }

    public void GuessRightCalculations(string theButton) {
       string button = theButton;
         StopTimerPhase2(); totalPoints = Mathf.RoundToInt(((timerPhase1 / timerPhase1Max) + pointsModifierP1) * (((timerPhase2 / timerPhase2Max) * pointsModifierP2) + 100)); guessHasBeenMade = true;
        foreach (FruitCardData fruitCard in fruitCards)
        {
          
            if (fruitCard.button == button)
            {
             
                fruitCard.card.transform.Find("Image").GetComponent<Animator>().SetTrigger("GuessMade"); 
            }
           
     

        }

    }

    public void GuessWrongCalculations(string theButton) 
    {
        string button = theButton;
        guessHasBeenMade = true;
        foreach (FruitCardData fruitCard in fruitCards)
        {

            if (fruitCard.button == button)
            {

                fruitCard.card.transform.Find("Image").GetComponent<Animator>().SetTrigger("GuessMade");
            }

        }



        totalPoints = 0; guessHasBeenMade = true; StopTimerPhase2(); 
    
    }

    public void Guess() 
    {
       List<string> allButtons = new List<string> { "A", "B", "X", "Y" };
        if (!guessHasBeenMade)
        {
            
            foreach (string button in allButtons)
            {
                if (Input.GetButtonDown(button))
                {
                    if (button == correctButton) { GuessRightCalculations(button); }
                    else { GuessWrongCalculations(button); }

                }


            }

        
                if (Input.GetAxisRaw("Horizontal") ==1 )
                {
                    if ("Right" == correctButton) { GuessRightCalculations("Right"); }
                else { GuessWrongCalculations("Right"); }

            }
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if ("Left" == correctButton) { GuessRightCalculations("Left"); }
                else { GuessWrongCalculations("Left"); }

            }
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                if ("Down" == correctButton) { GuessRightCalculations("Down"); }
                else { GuessWrongCalculations("Down"); }

            }
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                if ("Up" == correctButton) { GuessRightCalculations("Up"); }
                else { GuessWrongCalculations("Up"); }

            }

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
            selectedFruitsList.Add(optionsToEmpty[x]);
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
