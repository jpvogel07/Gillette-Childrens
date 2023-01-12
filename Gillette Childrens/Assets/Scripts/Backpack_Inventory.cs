using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack_Inventory : MonoBehaviour
{
    [SerializeField] GameObject Menu;

    public void openInventory()
    {
        Menu.SetActive(true);
    }

    public void closeInventory()
    {
        Menu.SetActive(false);
    }
}
