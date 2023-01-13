using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWisp : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    private void OnEnable()
    {
        end = GameObject.Find("Jade");
        start = GameObject.Find("inventory");
        this.GetComponent<Image>().sprite = start.GetComponent<Image>().sprite;
        this.GetComponent<Image>().color = Color.white;
        this.transform.position = start.transform.position;
    }
    private void Update()
    {
        if (this.transform.position == end.transform.position)
        {
            Destroy(this);
        }

        //travel to end
    }
}
