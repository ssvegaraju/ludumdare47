﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public float inputDelay = 0.3f;
    public AnimationCurve curve;
    public Color selectedOptionColor;
    public MainMenuButton[] buttons;
    public Transform menuHolder;
    public Camera mainCam;
    public Image cover;

    private int choiceIndex = 0;
    private float lastInputTime;
    private bool canInput = true;

    // Start is called before the first frame update
    void Start()
    {
        if (mainCam == null)
            mainCam = Camera.main;
        buttons[0].Hover();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastInputTime < inputDelay)
            return;
        if (!canInput)
            return;
        float input = Input.GetAxisRaw("Vertical");
        if (input == 0) {
            return;
        }
        if (Input.GetButtonDown("Submit")) {
            buttons[choiceIndex].Press();
            HideMenu();
            return;
        }
        int temp = choiceIndex;
        choiceIndex += (input < 0) ? -1 : 1;
        choiceIndex = Mod(choiceIndex, buttons.Length);
        buttons[temp].Deselect();
        buttons[choiceIndex].Hover();
    }
    
    public void LoadLevel() {
        StartCoroutine(LoadingAnim());
    }

    private IEnumerator LoadingAnim() {
        float startTime = Time.time;
        cover.CrossFadeAlpha(1, 0.3f, true);
        while (Time.time - startTime <= 0.3f) {
            mainCam.fieldOfView = Mathf.Lerp(90, 172, (Time.time - startTime) / 0.3f);
            yield return null;
        }

    }

    private void HideMenu() {
        canInput = false;
        menuHolder.gameObject.SetActive(false);
    }

    private int Mod(int num, int len) {
        if (num < 0) {
            return len - 1;
        } else if (num >= len) {
            return 0;
        }
        return num;
    }
}
