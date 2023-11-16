using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
   
    // Speed in pixels per second
    public float speed = 8f;

    void Update()
    {
        // Calculate the new position
        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.left * step);
    }
}
