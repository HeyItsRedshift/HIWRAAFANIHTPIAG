using UnityEngine;
using TMPro; 
using System.Collections;
using System;

public class RandomWord : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI categoryText;
    public TextMeshProUGUI describeText;
    public TextMeshProUGUI skipsText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI instructionText; 

    private WordGuessingGame guessingGame;
    private string[] descriptionMethods = new string[] { "sounds", "charade", "one word" };
    private System.Random random = new System.Random();
    private int totalPoints = 0; 
    private int skipCount = 0; 
    private const int maxSkips = 3; 
    private float timer = 30f;
    private bool isGameOver = false;

    void Start()
    {
        guessingGame = new WordGuessingGame();
        DisplayRandomWord();
        UpdateSkipsText();
        UpdateInstructionText(true);
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
  
            timer -= Time.deltaTime;
            UpdateTimerText();

            if (timer <= 0)
            {
                EndGame();
                return;
            }

            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
            {
                DisplayRandomWord();
            }

            // Handling skip input
            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Backspace)) && skipCount < maxSkips)
            {
                skipCount++;
                DisplayRandomWord();
                UpdateSkipsText();
            }
        }
    }

    void DisplayRandomWord()
    {
        StartCoroutine(ChangeWordWithMovement());
    }

    IEnumerator ChangeWordWithMovement()
    {
        float moveTime = 0.5f;
        Vector3 offScreenPosition = new Vector3(-6000, 8000, 0);
        Vector3 wordPosition = new Vector3(-16.933f, 609f, 0f); // Updated position for word
        Vector3 categoryPosition = new Vector3(-16.933f, 207.661f, 0f); // Updated position for category
        Vector3 descriptionPosition = new Vector3(-16.933f, -163.536f, 0f); // Updated position for description

        // Move the texts off-screen
        StartCoroutine(MoveText(wordText, offScreenPosition, moveTime));
        StartCoroutine(MoveText(categoryText, offScreenPosition, moveTime));
        StartCoroutine(MoveText(describeText, offScreenPosition, moveTime));

        yield return new WaitForSeconds(moveTime);

        // Change the word
        GameWord randomWord = guessingGame.ChooseRandomWord();
        wordText.text = "Word: " + randomWord.Word;

        // Move the word text into view
        yield return MoveText(wordText, wordPosition, moveTime);

        // Update and move the category text into view
        categoryText.text = "Category: " + randomWord.Category;
        yield return MoveText(categoryText, categoryPosition, moveTime);

        // Update and move the description method text into view
        describeText.text = "Describe using: " + GetRandomDescriptionMethod();
        yield return MoveText(describeText, descriptionPosition, moveTime);
    }




    IEnumerator MoveText(TextMeshProUGUI textElement, Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = textElement.transform.localPosition;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            textElement.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / duration);
            yield return null;
        }

        textElement.transform.localPosition = targetPosition;
    }
    string GetRandomDescriptionMethod()
    {
        int index = random.Next(descriptionMethods.Length);
        return descriptionMethods[index];
    }

    void UpdateSkipsText()
    {
        if (skipsText != null)
            skipsText.text = $"{maxSkips - skipCount} Skips Remaining";
        else
            Debug.LogError("skipsText is not assigned in the Inspector");
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

