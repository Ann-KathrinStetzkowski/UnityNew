using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private int frameCounter = 0;
    private int jumpCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter = frameCounter + 1;
        Debug.Log("Update! Framenumber:" + frameCounter);
    }

    void OnJump()
    {
        jumpCounter = jumpCounter + 1;
        Debug.Log("Jump! Jumpnumber" + jumpCounter);
        
    }

    void OnMove()
    {
        Debug.Log("Move!");
        
    }
    void OnSneak()
    {
        Debug.Log("Sneak!");
        
    }
}
