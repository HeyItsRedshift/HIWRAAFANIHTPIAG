using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class SelectAatStart : MonoBehaviour
{
    Transform child;
    bool selected;
    // Start is called before the first frame update
    void Start()
    {
        child = this.transform.GetChild(0);

    }

    private void OnEnable()
    {
        if (child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text != null)
        {
            if (child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text == "a" || child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text == "A")
            {
               
                    EventSystem.current.SetSelectedGameObject(this.gameObject);
                   
            
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text != null) 
        {
            if (child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text == "a" || child.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text == "A")
            {
                if (!selected)
                {
                    EventSystem.current.SetSelectedGameObject(this.gameObject);
                    selected = true;
                }
            }
        }
        
      
    }
}
