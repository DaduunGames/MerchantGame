using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonFreeze : MonoBehaviour
{
    public List<GameObject> Items;
    public BoxCollider triggerZone;
    public bool IsFrozen = false;

    GameObject linecontainer;
    public LineRenderer[] linesHorizontal;
    public LineRenderer[] linesVertical;
    public float RopeHeight;
    public float ropeThickness = 0.1f;
    public int HorizontalSegments;
    public int VerticalSegments;
   
    public List<RaycastHit> hits = new List<RaycastHit>(); 

    public GameObject debugPoint;
    
    private void Start()
    {
        triggerZone = GetComponent<BoxCollider>();
        linecontainer = transform.GetChild(0).gameObject;

        SetRopes(false, linesHorizontal, HorizontalSegments);
        SetRopes(false, linesVertical, VerticalSegments);
    }

    private void Update()
    {
        
    }


    public void toggleFreeze()
    {
        IsFrozen = !IsFrozen;

        if (IsFrozen)
        {
            foreach (GameObject item in Items)
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.parent = transform;
            }

            SetRopes(true, linesHorizontal, HorizontalSegments);
            SetRopes(true, linesVertical,VerticalSegments);
        }
        else
        {
            SetRopes(false, linesHorizontal, HorizontalSegments);
            SetRopes(false, linesVertical, VerticalSegments);

            foreach (GameObject item in Items)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.parent = null;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Item") 
        {
            if (col.gameObject.transform.parent.gameObject)
            {
                GameObject obj = col.gameObject.transform.parent.gameObject;

                if (!Items.Contains(obj))
                {
                    Items.Add(obj);
                }
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Item")
        {
            if (col.gameObject.transform.parent.gameObject)
            {
                GameObject obj = col.gameObject.transform.parent.gameObject;

                if (Items.Contains(obj))
                {
                    Items.Remove(obj);
                }
            }

        }
    }

    
   

    void SetRopes(bool visible, LineRenderer[] lines, int segments)
    {
        
        //print("setting lines");
        foreach (LineRenderer lr in lines)
        {
            if (visible)
            {
                linecontainer.SetActive(true);
                Vector3 pos = lr.transform.position;
                hits.Clear();
                float RopeLength = 0;
                RopeLength = lr.GetPosition(lr.positionCount - 1).z;
                

                for (int i = 0; i <= segments; i++)
                {
                    

                    Vector3 start = pos + lr.transform.up * RopeHeight + lr.transform.forward * ((RopeLength / segments) * i);
                    Vector3 direction = -lr.transform.up;

                    RaycastHit hit;
                    
                    Ray ray = new Ray(start, direction);

                   
                    //Debug.DrawRay(start, direction, Color.yellow, 100, true);

                    if (Physics.Raycast(ray, out hit, RopeHeight, LayerMask.GetMask("Ground", "ItemMesh")))
                    {
                        hits.Add(hit);
                        //Instantiate(debugPoint, hit.point, Quaternion.identity);
                    }

                    
                }

                lr.positionCount = hits.Count + 2;
                lr.SetPosition(0, Vector3.zero);
                lr.SetPosition(lr.positionCount - 1, new Vector3(0, 0, RopeLength));

                for (int e = 1; e < lr.positionCount-1; e++)
                {
                    float height = RopeHeight - hits[e - 1].distance + ropeThickness;
                    lr.SetPosition(e, new Vector3(0, height, 0));
                    float dist = Vector3.Distance(lr.GetPosition(e) + lr.transform.position, hits[e-1].point);
                    lr.SetPosition(e, new Vector3(0, height, dist));
                }
                
            }
            else
            {
                linecontainer.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        //if (lines[0])
        //{
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawSphere( (lines[0].transform.position + (lines[0].transform.rotation * new Vector3(0, 0, RopeLength))), 0.1f);

        //    Vector3 pos = lines[0].transform.position;
        //    Vector3 start = pos + lines[0].transform.rotation * new Vector3(0/RopeLength, RopeHeight, 0);
        //    Vector3 direction = start + lines[0].transform.rotation * Vector3.down;

        //    Gizmos.DrawSphere(start, 0.1f);
        //    Gizmos.DrawLine(start, direction);
        //}
    }
}
