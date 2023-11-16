using UnityEngine;

public class FruitController : MonoBehaviour
{
    // The name of the button that will cut this fruit, assigned by the FruitSpawner.
    public string cutButton;

    // Update is called once per frame
    void Update()
    {
        // Check if the cut button for this fruit is pressed.
        if (!string.IsNullOrEmpty(cutButton) && Input.GetButtonDown(cutButton))
        {
            // Call the Cut method when the button is pressed.
            Cut();
        }
    }

    // This method is called to "cut" the fruit.
    private void Cut()
    {
        // Implement the cutting logic here.
        // For example, you might trigger an animation, destroy the fruit, etc.
        Debug.Log("Cut the " + gameObject.name + " with button " + cutButton);

        // If you want to destroy the fruit after cutting, uncomment the line below.
        // Destroy(gameObject);
    }
}
