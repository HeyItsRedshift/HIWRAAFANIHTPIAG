using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OnActivateAddMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable() 
    {
        if (EventSystem.current != null) {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
