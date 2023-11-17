using UnityEngine;

public class FruitCutting : MonoBehaviour
{
    public string assignedButton; // The button that cuts this fruit
    public int scoreForOk = 5;
    public int scoreForGood = 10;
    public int scoreForPerfect = 15;

    public void InitializeFruit(string fruitName)
    {
        assignedButton = FruitManager.Instance.GetButtonAssignment(fruitName);
        // ... rest of initialization code
    }

    public void AttemptCut(string buttonPressed, int zone)
    {
        if (buttonPressed == assignedButton)
        {
            Cut(zone);
        }
    }

    private void Cut(int zone)
    {
        int pointsEarned = 0;
        switch (zone)
        {
            case 1:
            case 5:
                pointsEarned = scoreForOk;
                break;
            case 2:
            case 4:
                pointsEarned = scoreForGood;
                break;
            case 3:
                pointsEarned = scoreForPerfect;
                break;
        }

        ScorePoints(pointsEarned);
        // Play cutting animation, sound effects, etc.
    }

    private void ScorePoints(int points)
    {
        // Add points to the player's score
        Debug.Log($"Scored {points} points for cutting the {gameObject.name}.");
        // Update the score in your game (e.g., via a ScoreManager)
    }
}
