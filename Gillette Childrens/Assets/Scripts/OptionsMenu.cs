using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject optionsCloser;

    public void openMenu()
    {
        optionsMenu.SetActive(true);
        optionsCloser.SetActive(true);
    }

    public void closeMenu()
    {
        optionsMenu.SetActive(false);
        optionsCloser.SetActive(false);
    }
}
