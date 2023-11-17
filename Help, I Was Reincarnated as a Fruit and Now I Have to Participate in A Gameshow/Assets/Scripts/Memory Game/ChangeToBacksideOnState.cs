using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeToBacksideOnState : MonoBehaviour
{
    MemoryGameController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller = MemoryGameController.memoryGameController;
        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CardFlip2") ) {
            Image cardImage = this.gameObject.GetComponent<Image>();
            cardImage.sprite = controller.spriteList[8];
        }
    }
}
