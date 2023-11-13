using UnityEngine;
using TMPro; // Make sure to include this for TextMeshPro

public class YourGameScript : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI categoryText; 
    public TextMeshProUGUI describeText;

    private WordGuessingGame guessingGame;
    private string[] descriptionMethods = new string[] { "sounds", "charade", "one word" };
    private System.Random random = new System.Random(); 

    void Start()
    {
        guessingGame = new WordGuessingGame();
        DisplayRandomWord();
    }

    void DisplayRandomWord()
    {
        GameWord randomWord = guessingGame.ChooseRandomWord();

        if (wordText != null)
            wordText.text = "Word: " + randomWord.Word;
        else
            Debug.LogError("wordText is not assigned in the Inspector");

        if (categoryText != null)
            categoryText.text = "Category: " + randomWord.Category;
        else
            Debug.LogError("categoryText is not assigned in the Inspector");

        if (describeText != null)
            describeText.text = "Describe using: " + GetRandomDescriptionMethod();
        else
            Debug.LogError("describeText is not assigned in the Inspector");
    }

    string GetRandomDescriptionMethod()
    {
        int index2 = Random.RandomRange(0,descriptionMethods.Length);
        //int index = random.Next(descriptionMethods.Length);
        return descriptionMethods[index2];
    }
}
