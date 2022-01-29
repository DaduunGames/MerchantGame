using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    Camera cam;
    public GameObject hand;
    public Material previewMat;
    public Material previewMatNo;
    ItemPreviewSetter ips;
    public float PickupDistance = 3;
    public float HandScale = 0.5f;
    public float rotateSpeed = 1;
    bool IsHolding = false;

    GameObject HeldObj;
    GameObject ObjPreview;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }


    void Update()
    {
        


        //interact
        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Interact]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Interact]))
        {
            RaycastHit hit;
            Vector3 point = new Vector3(0.5f, 0.5f, 0);
            Ray ray = cam.ViewportPointToRay(point);

            if (Physics.Raycast(ray, out hit, PickupDistance))
            {
                TriggerCore trig = hit.collider.GetComponent<TriggerCore>();
                if (trig)
                {
                    trig.Interact();
                }
            }
        }

        if (Input.GetKeyDown(GS.keybinds.Primary[(int)GS.Binds.Pickup]) || Input.GetKeyDown(GS.keybinds.Secondary[(int)GS.Binds.Pickup]))
        {
            if (!IsHolding)
            {
                RaycastHit hit;
                Vector3 point = new Vector3(0.5f, 0.5f, 0);
                Ray ray = cam.ViewportPointToRay(point);

                if (Physics.Raycast(ray, out hit, PickupDistance) && !IsHolding)
                {
                    if (hit.collider.tag == "Item")
                    {
                        HeldObj = hit.collider.transform.parent.gameObject;

                        HeldObj.transform.parent = hand.transform;
                        HeldObj.transform.SetPositionAndRotation(hand.transform.position, hand.transform.rotation);
                        HeldObj.GetComponent<Rigidbody>().isKinematic = true;

                        IsHolding = true;
                    }
                }
            }
            else
            {
                if (ips.CanPlace && ObjPreview)
                {
                    HeldObj.transform.parent = null;
                    Rigidbody rb = HeldObj.GetComponent<Rigidbody>();
                    rb.isKinematic = false;

                    HeldObj.transform.SetPositionAndRotation(ObjPreview.transform.position, ObjPreview.transform.rotation);

                    IsHolding = false;
                }
            }
            
        }

        if (IsHolding && HeldObj)
        {
            RaycastHit hit;
            Vector3 point = new Vector3(0.5f, 0.5f, 0);
            Ray ray = cam.ViewportPointToRay(point);

            if (Physics.Raycast(ray, out hit, PickupDistance, LayerMask.GetMask("Ground", "ItemMesh")))
            {

                if (ObjPreview)
                {
                    ObjPreview.transform.position = hit.point;

                    ObjPreview.transform.Rotate(0, Input.GetAxis("Mouse ScrollWheel") * rotateSpeed, 0);
                }
                else
                {
                    GameObject temp = HeldObj.GetComponent<PhysicalItem>().itemInstance.GetMesh();
                    ObjPreview = Instantiate(temp);
                    ObjPreview.GetComponent<Collider>().isTrigger = true;
                    ObjPreview.AddComponent<Rigidbody>().isKinematic = true;
                    ObjPreview.layer = 0;
                    ObjPreview.tag = "Untagged";
                        
                    ips = ObjPreview.AddComponent<ItemPreviewSetter>();
                    ips.yes = previewMat;
                    ips.no = previewMatNo;
                }
            }
            else
            {
                Destroy(ObjPreview);
            }
        }
        else
        {
            Destroy(ObjPreview);
        }

        
    }
}
