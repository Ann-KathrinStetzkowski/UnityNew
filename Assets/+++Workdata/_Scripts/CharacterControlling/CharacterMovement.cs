using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
   // private int frameCounter = 0;
    //private int jumpCounter = 0;
    
    //Character hinzugefügt
    PlayerInput playerInput;
    private Rigidbody2D rb;
    private float inputDirection;
    
    //SerialzeFields fügen Variablen in den Inspector hinzu und man kann dann die InGame Elemente reinziehen und sie sind verbunden
    [SerializeField] private  float jumpForce = 10f;
    [SerializeField] private int firstJumpCount = 2;
    private int JumpCount;
    [SerializeField] private  float movementSpeed = 10f;
    [SerializeField] private float sprintSpeed = 15f;
    [SerializeField] private float sneakSPeed;
    private float tempSpeed;

    private float isSprinting;
    private float isSneaking;

    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask layerGroundcheck;
    
    private bool isFacingRight = true;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Character hinzugefügt
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;           //character dreht sich nicht mehr
        Debug.Log("Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sprintconditions hinzugefügt bzw. Speedconditions allgemein
        if (isSprinting > 0)
        {
            movementSpeed = sprintSpeed;
        }
        else if (isSprinting == 0 && isSneaking == 0)
        {
            movementSpeed = tempSpeed;
        }
        else if (isSneaking > 0)
        {
            movementSpeed = sneakSPeed;
        }
    }

    
    //physics based things go in here
    private void FixedUpdate()
    {//Geschwindigkeit wird zugewiesen für die Achsen
        rb.velocity = new Vector2(inputDirection * movementSpeed, rb.velocity.y);
    }

    void OnJump()
    { //Guckt ob sich der Character mit dem Ground überlappt
     if(Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius, layerGroundcheck))

     { //DoppelSprung hinzugefügt
         JumpCount = firstJumpCount;
     }
     if(JumpCount > 0)
     {
         rb.velocity = new Vector2(0f, jumpForce);
         Debug.Log("Jump!");
         JumpCount = JumpCount - 1;
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
            // es wird eingefügt, dass der Character sich dreht, je nachdem in welche Richtung man geht
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
    void OnSneak(InputValue inputValue)
    // sneaken hinzugefügt
    {
        isSneaking = inputValue.Get<float>();
    }
    
    void OnSprint(InputValue inputValue)
//sprinten hinzugefügt
    {
        isSprinting = inputValue.Get<float>();
        Debug.Log("Sprint!" + isSprinting);
    }

  
}
