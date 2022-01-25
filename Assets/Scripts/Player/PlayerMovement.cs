using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Variables")]
    //basic speed variables
    public float WalkSpeed = 1;
    public float MaxSpeed = 1;
    public float SideStepSpeedModifier = 0.75f;
    public float BackStepSpeedModifier = 0.75f;

    //movement logic
    Vector3 movement;
    float verticalRotation;
    bool IsJumping = false;
    bool grounded;

    // variables for jump logic
    public float Jumpspeed = 0.3f;
    public float MaxJumpTime = 0.5f;
    float jumpTime;
    public float JumpDelay = 0.5f;
    float jumpDelay;

    //Hope gravity doesnt need explaining
    public float Gravity = 10;

    //min and max allowable cam tilt
    public float CamMaxTilt = 80;
    public float CamMinTilt = -90;

    //gotta disable input when in vehicle
    public bool InVehicle = false;

    [Header("References")]
    public GameObject thisObj;
    public Camera cam;
    private CharacterController cc;

   

    void Start()
    {
        movement = Vector3.zero;

        cc = GetComponent<CharacterController>();
        thisObj = gameObject;

        
    }


    void Update()
    {
        #region mouse movement
        float mouseX = Input.GetAxis("Mouse X") * GS.MouseXSensativity, mouseY = Input.GetAxis("Mouse Y") * GS.MouseYSensativity;

        if (!GS.InvertPitch)
            mouseY = -mouseY;
        verticalRotation += mouseY * GS.MouseYSensativity;

        verticalRotation = Mathf.Clamp(verticalRotation, CamMinTilt, CamMaxTilt);

        transform.Rotate(0, mouseX * GS.MouseXSensativity, 0);
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        #endregion


        if (!InVehicle)
        {
            MakecharacterMove();
        }
    }

    private void MakecharacterMove()
    {
        movement.y -= Gravity;


        grounded = cc.isGrounded;

        #region WASD
        if (movement.x > 0)
        {
            movement.x -= WalkSpeed / 2;
        }
        if (movement.z > 0)
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

        //Forward
        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkForwards]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkForwards]))
        {
            movement.z += WalkSpeed;
        }

        //Backward
        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkBackwards]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkBackwards]))
        {
            movement.z -= WalkSpeed;

        }

        //left
        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkLeft]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkLeft]))
        {
            movement.x -= WalkSpeed;

        }

        //right
        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkRight]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkRight]))
        {
            movement.x += WalkSpeed;

        }

        movement.x = Mathf.Clamp(movement.x, -MaxSpeed, MaxSpeed);
        movement.z = Mathf.Clamp(movement.z, -MaxSpeed, MaxSpeed);
        #endregion

        #region jumping
        if (!IsJumping)
        {
            if (jumpDelay <= 0 && (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.Jump]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.Jump])))
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

        if (cc.isGrounded && !(Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.Jump]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.Jump])))
        {
            IsJumping = false;
            movement.y = -2;
        }

        if (IsJumping)
        {
            if (jumpTime > 0)
            {
                movement.y = Jumpspeed * (jumpTime / MaxJumpTime);
                jumpTime -= Time.deltaTime;
            }
        }
        #endregion

       

        cc.Move(transform.rotation * movement * Time.deltaTime);
    }

    
}
