using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject secondSpawner; // Assign the second fruit spawner in the inspector
    private int numberOfPlayers = 2; // Pseudo number of players, change as needed

    void Start()
    {
        // If there are only 2 players, deactivate the second spawner
        if (numberOfPlayers == 3)
        {
            if (secondSpawner != null)
            {
                secondSpawner.SetActive(false);
            }
        }
        else if (numberOfPlayers == 3)
        {
            if (secondSpawner != null)
            {
                secondSpawner.SetActive(true);
            }
        }
        // Add more conditions if needed for different player counts
    }

    // Method to update the number of players (for future use)
    public void SetNumberOfPlayers(int playerCount)
    {
        numberOfPlayers = playerCount;
    }
}
