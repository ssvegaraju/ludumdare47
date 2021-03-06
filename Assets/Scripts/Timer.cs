﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool timerIsRunning = false;
    public float time = 0;
    public TextMeshPro textMesh;

    private void Start() {
        GetComponent<PlayerMovement>().OnReachedGoal += StopTimer;
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update() {
        if (timerIsRunning) {
                time += Time.deltaTime;
                DisplayTime(time);
        }
    }

    void DisplayTime(float timeToDisplay) {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textMesh.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    public void StopTimer() {
        timerIsRunning = false;
        PlayerPrefs.SetString("time", textMesh.text);
    }
    public void StartTimer() {
        timerIsRunning = true;
    }

    public void ResetTimer() {
        time = 0f;
    }
}