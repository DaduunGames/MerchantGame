using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI info;
    public Scrollbar conditoinBar;
    public Camera cam;
    public float infoDistance = 3;

    public void SetInfo(ItemDB.eName name, int ammount, float condition)
    {
        conditoinBar.size = condition / 100;

        string newText = name.ToString() + " x" + ammount;
        info.text = newText;
    }


    private void Update()
    {
        RaycastHit hit;
        Vector3 point = new Vector3(0.5f, 0.5f, 0);
        Ray ray = cam.ViewportPointToRay(point);

        if (Physics.Raycast(ray, out hit, infoDistance, LayerMask.GetMask("ItemMesh")))
        {
            
            PhysicalItem item = hit.transform.GetComponent<PhysicalItem>();
            if (item)
            {
                Panel.SetActive(true);
                SetInfo(item.itemInstance.Name, item.itemInstance.Amount, item.itemInstance.Condition);
            }
            
        }
        else
        {
            Panel.SetActive(false);
        }
    }
}
