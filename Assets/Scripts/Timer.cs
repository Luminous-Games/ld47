using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    bool pause = false;
    float time = 0;
    public TextMeshProUGUI display;
    public TextMeshProUGUI display2;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!pause)
        {
            time += Time.deltaTime;
            var timeSpan = TimeSpan.FromSeconds(time);
            display.text = string.Format("{0:D2}:{1:D2}:{2:D1}", (int)timeSpan.TotalMinutes, timeSpan.Seconds, (int)Mathf.Round(timeSpan.Milliseconds / 100));
            display2.text = string.Format("{0:D2}:{1:D2}:{2:D1}", (int)timeSpan.TotalMinutes, timeSpan.Seconds, (int)Mathf.Round(timeSpan.Milliseconds / 100));
        }
    }

    public void Pause()
    {
        this.pause = true;
    }

    public void Reset()
    {
        this.pause = false;
        this.time = 0f;


    }
}
