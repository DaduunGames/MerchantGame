using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;

    public float WalkSpeed = 1;
    public float MaxSpeed = 1;
    public float SideStepSpeedModifier = 0.75f;
    public float BackStepSpeedModifier = 0.75f;

    public float Jumpspeed = 0.3f;
    public float MaxJumpTime = 0.5f;
    float jumpTime;
    public float JumpDelay = 0.5f;
    float jumpDelay;
    bool IsJumping = false;
    public float Gravity = 10;

    bool grounded;

    Vector3 movement;
    float verticalRotation;
    public float CamMaxTilt = 80;
    public float CamMinTilt = -90;

    private CharacterController cc;

    

    public enum Binds
    {
        //enums used with static Controls[] list.

        WalkForwards = 0,
        WalkLeft = 1,
        WalkBackwards = 2,
        WalkRight = 3,
        Interact = 4,
        Jump = 5
    }

    void Start()
    {
        movement = Vector3.zero;
       
        cc = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        movement.y -= Gravity;


        float mouseX = Input.GetAxis("Mouse X"), mouseY = Input.GetAxis("Mouse Y");

        if (!GlobalScript.InvertPitch)
            mouseY = -mouseY;
        verticalRotation += mouseY * GlobalScript.MouseYSensativity;
        
        verticalRotation = Mathf.Clamp(verticalRotation, CamMinTilt, CamMaxTilt);

        transform.Rotate(0, mouseX * GlobalScript.MouseXSensativity, 0);
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        grounded = cc.isGrounded;

        

        if(movement.x > 0)
        {
            movement.x -= WalkSpeed / 2;
        }
        if(movement.z > 0)
        {
            movement.z -= WalkSpeed / 2;
        }
        if (movement.x < 0)
        {
            movement.x += WalkSpeed / 2;
        }
        if (movement.z < 0)
        {
            movement.z += WalkSpeed / 2;
        }

        //All Key Inputs

        //Forward
        if (Input.GetKey(GlobalScript.Controls[(int)Binds.WalkForwards]) || Input.GetKey(GlobalScript.SecondaryControls[(int)Binds.WalkForwards]))
        {
            movement.z += WalkSpeed;
        }

        //Backward
        if (Input.GetKey(GlobalScript.Controls[(int)Binds.WalkBackwards]) || Input.GetKey(GlobalScript.SecondaryControls[(int)Binds.WalkBackwards]))
        {
            movement.z -= WalkSpeed;

        }

        //left
        if (Input.GetKey(GlobalScript.Controls[(int)Binds.WalkLeft]) || Input.GetKey(GlobalScript.SecondaryControls[(int)Binds.WalkLeft]))
        {
            movement.x -= WalkSpeed;

        }

        //right
        if (Input.GetKey(GlobalScript.Controls[(int)Binds.WalkRight]) || Input.GetKey(GlobalScript.SecondaryControls[(int)Binds.WalkRight]))
        {
            movement.x += WalkSpeed;

        }

        if (!IsJumping)
        {
            if ( jumpDelay <= 0 && (Input.GetKey(GlobalScript.Controls[(int)Binds.Jump]) || Input.GetKey(GlobalScript.SecondaryControls[(int)Binds.Jump])))
            {
                IsJumping = true;
                jumpTime = MaxJumpTime;
                jumpDelay = JumpDelay;
            }

            if (jumpDelay > 0)
            {
                jumpDelay -= Time.deltaTime;
            }
        }

        if (cc.isGrounded && !(Input.GetKey(GlobalScript.Controls[(int)Binds.Jump]) || Input.GetKey(GlobalScript.SecondaryControls[(int)Binds.Jump])))
        {
            IsJumping = false;
            movement.y = -2;
        }

        if (IsJumping)
        {
            if (jumpTime > 0)
            {
                movement.y = Jumpspeed * (jumpTime/MaxJumpTime);
                jumpTime -= Time.deltaTime;
            }
        }

        

        


        movement.x = Mathf.Clamp(movement.x, -MaxSpeed , MaxSpeed);
        movement.z = Mathf.Clamp(movement.z, -MaxSpeed , MaxSpeed);

        cc.Move(transform.rotation * movement * Time.deltaTime);




        //interact
        if (Input.GetKeyDown(GlobalScript.Controls[(int)Binds.Interact]) && Input.GetKeyDown(GlobalScript.SecondaryControls[(int)Binds.Interact]))
        {

        }
    }
}
