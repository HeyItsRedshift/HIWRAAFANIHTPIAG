using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimateOnEnable : MonoBehaviour
{
    bool animationTriggered=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Image>().IsActive() && !animationTriggered)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("ButtonFadeIn");
            animationTriggered = true;
        }
    }
    private void OnEnable()
    {
    }
}
