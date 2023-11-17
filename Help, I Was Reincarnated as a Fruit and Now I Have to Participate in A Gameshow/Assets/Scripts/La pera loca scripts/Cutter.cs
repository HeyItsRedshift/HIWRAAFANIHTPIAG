using UnityEngine;

public class Cutter : MonoBehaviour
{
    public Transform cutterTransform; // Assign the transform of the cutter
    void Update()
    {

       
            CheckForCut("A");
            CheckForCut("B");
            CheckForCut("X");
            CheckForCut("Y");

        
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
                        int zone = int.Parse(hitCollider.gameObject.name.Replace("Zone", ""));
                        fruitCutting.AttemptCut(buttonName, zone);
                    }
                }
            }
        }
    }
}
