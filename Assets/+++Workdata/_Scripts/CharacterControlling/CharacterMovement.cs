using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
   // private int frameCounter = 0;
    //private int jumpCounter = 0;

    private Rigidbody2D rb;
    private float inputDirection;
    
    //Serialize Field zeigt Variablen im Inspektor an 
    [SerializeField] private  float jumpForce = 10f;
    [SerializeField] private  float movementSpeed = 10f;

    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask layerGroundcheck;

    private bool isFacingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;           //character dreht sich nicht mehr
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
       // frameCounter = frameCounter + 1;
//        Debug.Log("Update! Framenumber:" + frameCounter);
    }

    
    //physics based things go in here
    private void FixedUpdate()
    {//Geschwindigkeit wird zugewiesen für die Achsen
        rb.velocity = new Vector2(inputDirection * movementSpeed, rb.velocity.y);
    }

    void OnJump()
    { //Guckt ob sich der Character mit dem Ground überlappt
     if(Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius, layerGroundcheck))

     { //Guckt ob sich der Character mit dem Ground überlappt
   
         rb.velocity = new Vector2(0f, jumpForce);
     Debug.Log("Jump!");
     }
    }

    void OnMove(InputValue inputValue)
    {
        inputDirection = inputValue.Get<float>();
        Debug.Log("Move!" + inputDirection);
        
        
        // zwei && sind ein normales und ( beide conditions müssen erfüllt sein hier)
        // zwei || sind ein oder ( eins von beiden muss erfüllt sein)
        if (inputDirection > 0 && !isFacingRight)
        {
            Flip();
        } else if (inputDirection < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {       //Localscale ist ein Vector 3, weil er 3 Werte hat (x,y,z)
        Vector3 currentScale = transform.localScale;
        currentScale.x = currentScale.x * -1;
        transform.localScale = currentScale;

        //! = Gegenteil von etwas 
        isFacingRight = !isFacingRight;

    }
    void OnSneak()
    {
        
        Debug.Log("Sneak!" );
        
    }
    
    void OnSprint(InputValue inputValue)
    {
        float isSprinting = inputValue.Get<float>();
        Debug.Log("Sprint!" + isSprinting);
       
        
    }
}
