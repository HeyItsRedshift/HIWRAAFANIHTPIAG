using UnityEngine;
using TMPro; // Make sure to include this for TextMeshPro
using System; // For System.Random

public class RandomWord : MonoBehaviour
{
    public TextMeshProUGUI wordText; // Assign this in the Unity Inspector
    public TextMeshProUGUI categoryText; // Assign this in the Unity Inspector
    public TextMeshProUGUI describeText; // Text for the description method
    public TextMeshProUGUI skipsText; // Text for displaying remaining skips
    public TextMeshProUGUI timerText; // Text for displaying the timer
    public TextMeshProUGUI gameOverText; // Text for displaying "GAME OVER" and points
    public TextMeshProUGUI instructionText; // Text for "Press X if you guessed right" instruction
    public TextMeshProUGUI totalPointsText;
    private WordGuessingGame guessingGame;
    private string[] descriptionMethods = new string[] { "sounds", "charade", "one word" };
    private System.Random random = new System.Random();
    private int totalPoints = 0; // Points accumulator
    private int skipCount = 0; // Number of skips used
    private const int maxSkips = 3; // Maximum number of skips allowed
    private float timer = 30f; // 30 seconds timer
    private bool isGameOver = false;
    private Animator animator;

    void Start()
    {
        guessingGame = new WordGuessingGame();
        DisplayRandomWord();
        UpdateSkipsText();
        UpdateInstructionText(true); // Set the instruction text at the start
        gameOverText.gameObject.SetActive(false); // Hide game over text initially
        totalPointsText.text = $"{totalPoints} ";
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Update timer
            timer -= Time.deltaTime;
            UpdateTimerText();

            // Check for game over
            if (timer <= 0)
            {
                EndGame();
                return;
            }

            // Check for input to generate a new word
            if (Input.GetButtonDown("A") || Input.GetKeyDown(KeyCode.Return))
            {
                AccumulatePoints(DisplayRandomWord().Points);
            }

            // Handling skip input
            if ((Input.GetButtonDown("B") || Input.GetKeyDown(KeyCode.Backspace)) && skipCount < maxSkips)
            {
                skipCount++;
                DisplayRandomWord();
                UpdateSkipsText();
            }
        }
    }

    GameWord DisplayRandomWord()
    {
        GameWord randomWord = guessingGame.ChooseRandomWord();

        if (wordText != null)
        {
            wordText.text = randomWord.Word;
        }
           
        else
        {
            Debug.LogError("wordText is not assigned in the Inspector");
        }
          

        if (categoryText != null)
        {
            categoryText.text = randomWord.Category;
        }

        else
        {
            Debug.LogError("categoryText is not assigned in the Inspector");
        }
           

        if (describeText != null)
        {
            describeText.text = GetRandomDescriptionMethod();
        }

        else
        {
            Debug.LogError("describeText is not assigned in the Inspector");
        }

        return randomWord;
    }

    string GetRandomDescriptionMethod()
    {
        int index = random.Next(descriptionMethods.Length);
        return descriptionMethods[index];
    }

    void AccumulatePoints(int points)
    {
        totalPoints += points;
        // Points are now accumulated but not displayed
        totalPointsText.text = $"{totalPoints} ";
    }

    void UpdateSkipsText()
    {
        if (skipsText != null)
        {
            skipsText.text = $"{maxSkips - skipCount} Skips Remaining";
        }

        else
        {
            Debug.LogError("skipsText is not assigned in the Inspector");
        }
         
    }

    void UpdateTimerText()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.Max(0, Mathf.CeilToInt(timer)).ToString();
        else
            Debug.LogError("timerText is not assigned in the Inspector");
    }

    void UpdateInstructionText(bool isGameActive)
    {
        if (instructionText != null)
            instructionText.text = isGameActive ? "Press X if you guessed right" : "";
        else
            Debug.LogError("instructionText is not assigned in the Inspector");
    }

    void EndGame()
    {
        isGameOver = true;

        // Clearing texts of all other UI elements
        if (wordText != null) wordText.text = "";
        if (categoryText != null) categoryText.text = "";
        if (describeText != null) describeText.text = "";
        if (skipsText != null) skipsText.text = "";
        if (timerText != null) timerText.text = "";

        UpdateInstructionText(false); // Clear the instruction text

        // Display the game over text
        if (gameOverText != null)
        {
            gameOverText.text = "GAME OVER\nTotal Points: " + totalPoints;
            gameOverText.gameObject.SetActive(true);
        }
        else
            Debug.LogError("gameOverText is not assigned in the Inspector");
    }
}
