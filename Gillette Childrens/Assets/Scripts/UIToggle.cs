using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    private bool vis;
    [SerializeField] AnimationClip toggleIn, toggleOut;
    [SerializeField] Animator anim;

    public void menu()
    {
        if (!rest()) {
            if (vis)
            {
                Debug.Log("in");
                anim.SetTrigger("in");
                vis = false;
            }
            else
            {
                Debug.Log("out");
                anim.SetTrigger("out");
                vis = true;
            } 
        }
    }

    private bool rest()
    {
        return anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}
