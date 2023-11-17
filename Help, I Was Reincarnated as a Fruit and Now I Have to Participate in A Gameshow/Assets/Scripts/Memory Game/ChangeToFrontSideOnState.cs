using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeToFrontSideOnState : MonoBehaviour
{
    MemoryGameController controller;
    string myFruit;
    Sprite mySprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        controller = MemoryGameController.memoryGameController;
        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CardFlipEnd"))
        {
            foreach (FruitCardData fruitCard in controller.fruitCards)
            {
                if (fruitCard.card.name == this.gameObject.transform.parent.name) { myFruit = fruitCard.fruit; print(myFruit); }

            }
            switch (myFruit)
            {
                case "Banana":
                    mySprite = controller.spriteList[0];
                    break;
                case "Tomato":
                    mySprite = controller.spriteList[1];
                    break;
                case "Watermelon":
                    mySprite = controller.spriteList[2];
                    break;
                case "Cherries":
                    mySprite = controller.spriteList[3];
                    break;
                case "Orange":
                    mySprite = controller.spriteList[4];
                    break;
                case "Apple":
                    mySprite = controller.spriteList[5];
                    break;
                case "Grapes":
                    mySprite = controller.spriteList[6];
                    break;
                case "Strawberry":
                    mySprite = controller.spriteList[7];
                    break;
                default:
                    break;
            }

            Image cardImage = this.gameObject.GetComponent<Image>();
            cardImage.sprite = mySprite;
        }
    }
}
