using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class FruitManager : MonoBehaviour
{
    public static FruitManager Instance { get; private set; }

    private Dictionary<string, string> fruitButtonAssignments = new Dictionary<string, string>();
    private List<string> fruitNames = new List<string> { "Apple", "Banana", "Orange", "Pear" }; // Add more fruit names as needed
    private List<string> buttons = new List<string> { "A", "B", "X", "Y" };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeButtonAssignments();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeButtonAssignments()
    {
        // Randomize the buttons list
        buttons = buttons.OrderBy(x => Random.value).ToList();

        // Assign buttons to fruits
        for (int i = 0; i < fruitNames.Count; i++)
        {
            fruitButtonAssignments[fruitNames[i]] = buttons[i];
        }
    }

    public string GetButtonAssignment(string fruitName)
    {
        if (fruitButtonAssignments.TryGetValue(fruitName, out string button))
        {
            return button;
        }
        Debug.LogError("Button not assigned for fruit: " + fruitName);
        return null;
    }

    // Other methods for the game state management
}
