using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MainMenuButton : MonoBehaviour
{
    public event Action OnPressed;
    public event Action OnHover;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Hover() {
        anim.SetTrigger("Hover");
    }

    public void Press() {
        anim.SetTrigger("Press");
    }

    public void Deselect() {
        anim.SetTrigger("Deselect");
    }
}
