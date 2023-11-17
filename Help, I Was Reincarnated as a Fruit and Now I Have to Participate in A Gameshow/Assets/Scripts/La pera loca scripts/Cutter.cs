using UnityEngine;

public class Cutter : MonoBehaviour
{
    public Transform cutterTransform; // Assign the transform of the cutter
    public float cuttingDuration = 60.0f; // Adjust the cutting duration as needed
    private float currentTime = 0.0f;

    void Update()
    {
        
            currentTime += Time.deltaTime;

        // Check if the cutting duration has not been exceeded
        if (currentTime <= cuttingDuration)
        {
            CheckForCut("A");
            CheckForCut("B");
            CheckForCut("X");
            CheckForCut("Y");

        }
    }

    void CheckForCut(string button)
    {
        string buttonName = button;
        if (Input.GetButtonDown(buttonName))
        {
            print("checking");
            Collider2D[] hitColliders = Physics2D.OverlapPointAll(cutterTransform.position);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("FruitZone"))
                {
                    FruitCutting fruitCutting = hitCollider.GetComponentInParent<FruitCutting>();
                    if (fruitCutting != null && fruitCutting.assignedButton == buttonName)
                    {
                        int zone = int.Parse(hitCollider.gameObject.name.Replace("Zone ", ""));
                        fruitCutting.AttemptCut(buttonName, zone);
                    }
                }
            }
        }
    }
}
