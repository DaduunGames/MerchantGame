using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreviewSetter : MonoBehaviour
{
    public Material yes;
    public Material no;

    public bool CanPlace = true;

    private void Start()
    {
        GetComponent<Renderer>().material = yes;
        CanPlace = true;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer != 6 && col.gameObject.layer != 7 && col.gameObject.layer != 8)
        {
            GetComponent<Renderer>().material = no;
            CanPlace = false;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        GetComponent<Renderer>().material = yes;
        CanPlace = true;
    }
}
