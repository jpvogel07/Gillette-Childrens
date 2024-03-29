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
    [SerializeField] GameObject backpackCloser;
    [SerializeField] GameObject backpackBlocker;
    public TextMeshProUGUI text;
    [SerializeField] string[] lostDescriptions;
    [SerializeField] string[] foundDescriptions;
    [SerializeField] Image[] initialized;
    [SerializeField] Sprite[] silhouettes;
    [SerializeField] Sprite[] images;
    public bool[] obtained;

    private void Start()
    {
        Debug.Log("Initialized inventory");
        int k = 0;
        foreach (Image item in initialized)
        {
            initialized[k].sprite = silhouettes[k];
            obtained[k] = false;
            k++;
            Debug.Log("Got here are the sprites correct?");
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
        backpackCloser.SetActive(true);
        backpackBlocker.SetActive(true);
    }

    public void closeInventory()
    {
        closeDesc();
        menu.SetActive(false);
        backpackCloser.SetActive(false);
        backpackBlocker.SetActive(false);
    }

    public void openDesc(int position)
    {
        descMenu.SetActive(true);
        displayDesc(position);
        closeButton.SetActive(true);
        backpackCloser.SetActive(false);
    }

    public void closeDesc()
    {
        descMenu.SetActive(false);
        closeButton.SetActive(false);
        backpackCloser.SetActive(true);
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
