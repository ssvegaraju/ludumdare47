using Shapes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    [Range(0,1)]
    public float timeSlowAmount = 0.2f;
    public float maxDuration = 5f;
    public Disc ui;

    private float currentUsage;
    private bool onCooldown = false;
    private bool timeSlowed = false;

    // Start is called before the first frame update
    void Start()
    {
        currentUsage = maxDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1)) {
            RestartTime();
        }
        if (!onCooldown && currentUsage > 0f && Input.GetMouseButton(1)) {
            if (timeSlowed) {
                currentUsage -= Time.deltaTime;
                ui.AngRadiansEnd = (2 * Mathf.PI * currentUsage / maxDuration) + (Mathf.PI / 2);
            } else {
                SlowTime();
            }
        }
        if (currentUsage <= 0f) {
            RestartTime();
        }
        if (onCooldown) {
            currentUsage += Time.deltaTime;
            ui.AngRadiansEnd = (2 * Mathf.PI * currentUsage / maxDuration) + (Mathf.PI / 2);
        }
        if (currentUsage >= maxDuration) {
            onCooldown = false;
            currentUsage = maxDuration;
        }
    }

    private void SlowTime() {
        Time.timeScale = timeSlowAmount;
        currentUsage -= Time.deltaTime;
        timeSlowed = true;
    }

    private void RestartTime() {
        onCooldown = true;
        if (currentUsage < 0)
            currentUsage = 0;
        currentUsage += Time.deltaTime;
        Time.timeScale = 1;
        timeSlowed = false;
    }
}
