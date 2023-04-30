using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float fadeSpeed=1f;
    public Image img;

    void OnEnable()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        for (float i = fadeSpeed; i >= 0; i -= Time.deltaTime)
        {
            img.color = new Color(255, 255, 255, i);
            yield return null;
        }
    }
}
