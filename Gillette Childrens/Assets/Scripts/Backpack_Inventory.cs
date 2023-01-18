using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack_Inventory : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] Image[] initialized;
    [SerializeField] Sprite[] Silhouettes;
    [SerializeField] Sprite[] Images;
    public bool[] obtained;

    private void Start()
    {
        int k = 0;
        foreach (Image item in initialized)
        {
            initialized[k].sprite = Silhouettes[k];
            obtained[k] = false;
            k++;
        }
    }

    public void obtainAll()
    {
        int k = 0;
        foreach (Image item in initialized)
        {
            if (obtained[k] == false)
            {
                initialized[k].sprite = Images[k];
                obtained[k] = true;
            } else
            {
                initialized[k].sprite = Silhouettes[k];
                obtained[k] = false;
            }
            k++;
        }

    }
    public void openInventory()
    {
        Menu.SetActive(true);
    }

    public void closeInventory()
    {
        Menu.SetActive(false);
    }


}
