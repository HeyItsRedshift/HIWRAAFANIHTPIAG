using UnityEngine;

public class CuttingArea : MonoBehaviour
{
    private FruitSpawnData currentFruit;
    private KeyCode assignedButton;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object is a fruit
        if (other.gameObject.CompareTag("Fruit"))
        {
            currentFruit = other.gameObject.GetComponent<FruitSpawnData>();
            // Get the assigned button for this fruit from your mapping system
            assignedButton =0; // Implement your logic to get the correct button
        }
    }

    void Update()
    {
        if (currentFruit != null && Input.GetKeyDown(assignedButton))
        {
            // Check the timing of the cut
            CheckCutTiming();
        }
    }

    void CheckCutTiming()
    {
        // Implement logic to check the timing and assign score
        // For example, you can check the position of the fruit within the area
        // and assign scores accordingly

        // After checking, clear the current fruit
        currentFruit = null;
    }
}
