using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Backpack_Inventory : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject descMenu;
    [SerializeField] GameObject closeButton;
    [SerializeField] GameObject blocker;
    [SerializeField] GameObject blocker2;
    [SerializeField] GameObject blocker3;
    [SerializeField] GameObject blocker4;
    public TextMeshProUGUI text;
    [SerializeField] string[] lostDescriptions;
    [SerializeField] string[] foundDescriptions;
    [SerializeField] Image[] initialized;
    [SerializeField] Sprite[] silhouettes;
    [SerializeField] Sprite[] images;
    public bool[] obtained;

    private void Start()
    {
        int k = 0;
        foreach (Image item in initialized)
        {
            initialized[k].sprite = silhouettes[k];
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
                initialized[k].sprite = images[k];
                obtained[k] = true;
            } else
            {
                initialized[k].sprite = silhouettes[k];
                obtained[k] = false;
            }
            k++;
        }

    }

    public void obtainItem(int position)
    {
        initialized[position].sprite = images[position];
        obtained[position] = true;
    }
    public void openInventory()
    {
        menu.SetActive(true);
        blocker.SetActive(true);
        blocker2.SetActive(true);
        blocker3.SetActive(true);
        blocker4.SetActive(true);
    }

    public void closeInventory()
    {
        menu.SetActive(false);
        blocker.SetActive(false);
        blocker2.SetActive(false);
        blocker3.SetActive(false);
        blocker4.SetActive(false);
    }

    public void openDesc(int position)
    {
        descMenu.SetActive(true);
        displayDesc(position);
        closeButton.SetActive(false);
    }

    public void closeDesc()
    {
        descMenu.SetActive(false);
        closeButton.SetActive(true);
    }

    public void displayDesc(int position)
    {
        if (obtained[position] == true)
        {
            string input = foundDescriptions[position];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(input));
        } else if(obtained[position] == false)
        {
            string input = lostDescriptions[position];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(input));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return null;
        }
        
    }
}
