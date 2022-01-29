using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonMount : MonoBehaviour
{
    PlayerMovement player;
    CharacterController cc;
    public Transform seat;
    public Vector3 dismountOffset;
    Vector3 movement = Vector3.zero;
    public float Rotation = 0;

    public float WagonSpeed;
    public float MaxSpeed;
    public float RotateSpeed;
    public float MaxRotateSpeed;

    public bool IsMounted = false;
    public float MountDelay = 0.5f;
    private float delayTimer;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        cc = GetComponent<CharacterController>();
        IsMounted = false;
    }

    private void Update()
    {
        if (IsMounted)
        {
            MoveWagon();
            if (delayTimer <= 0)
            {
                if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Interact]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Interact]))
                {
                    Dismount();
                }
            }
            else
            {
                delayTimer -= Time.deltaTime;
            }
            
        }
    }

    void MoveWagon()
    {
        #region inertia dampener
        if (movement.x > 0)
        {
            movement.x -= WagonSpeed / 2;
        }
        if (movement.z > 0)
        {
            movement.z -= WagonSpeed / 2;
        }
        if (movement.x < 0)
        {
            movement.x += WagonSpeed / 2;
        }
        if (movement.z < 0)
        {
            movement.z += WagonSpeed / 2;
        }
        if (Rotation > 0)
        {
            Rotation -= RotateSpeed / 2;
        }
        if (Rotation < 0)
        {
            Rotation += RotateSpeed / 2;
        }
        #endregion

        #region Move keys
        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkForwards]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkForwards]))
        {
            movement.z += WagonSpeed;
        }
        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkLeft]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkLeft]))
        {
            Rotation -= RotateSpeed;
        }
        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkRight]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkRight]))
        {
            Rotation += RotateSpeed;
        }
        if (Input.GetKey(GS.keybinds.Primary[(int)GS.Binds.WalkBackwards]) || Input.GetKey(GS.keybinds.Secondary[(int)GS.Binds.WalkBackwards]))
        {
            movement.z -= WagonSpeed;
        }

        movement.x = Mathf.Clamp(movement.x, -MaxSpeed, MaxSpeed);
        movement.z = Mathf.Clamp(movement.z, -MaxSpeed, MaxSpeed);
        Rotation = Mathf.Clamp(Rotation, -MaxRotateSpeed, MaxRotateSpeed);
        #endregion

        transform.RotateAround(seat.position, Vector3.up, Rotation * Time.deltaTime);
        cc.Move(transform.rotation * movement * Time.deltaTime);
    }

    public void Mount()
    {
        delayTimer = MountDelay;
        print("attempting to mount");
        IsMounted = true;
        player.InVehicle = true;
        player.transform.SetPositionAndRotation(seat.position, seat.rotation);
        player.transform.parent = seat;
    }

    public void Dismount()
    {
        IsMounted = false;
        player.InVehicle = false;
        player.transform.SetPositionAndRotation(seat.position + dismountOffset, seat.rotation);
        player.transform.parent = null;
    }
}

