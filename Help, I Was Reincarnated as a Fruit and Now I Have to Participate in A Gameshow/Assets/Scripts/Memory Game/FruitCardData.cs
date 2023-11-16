using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FruitCardData 
{
[SerializeField]  public  GameObject card;
    [SerializeField] public string fruit;
 
    public FruitCardData(GameObject Card)
    {
        fruit = "none";
        card = Card;
    }
}
