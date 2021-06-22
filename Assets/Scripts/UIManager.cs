using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;

public class UIManager : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI explosionLeftText;
    [SerializeField] private TextMeshProUGUI timePassedText;
    [SerializeField] private ExplosionMaker explosionMaker;

    private Stopwatch stopWatch;

    public GameObject dialoguePanel;
    public GameObject winPanel;

    float timePassed = 0f;

    private bool timerStarted = false;

    void Update()
    {
        if (timerStarted)
        {
            timePassed += Time.deltaTime;
        }

        var ts = TimeSpan.FromSeconds(timePassed);
        timePassedText.text = string.Format("{0:00}:{1:00}:{2:00}", ts.TotalMinutes, ts.Seconds, ts.Milliseconds);

        //explosionLeftText.text = explosionMaker.ExplosionsLeft.ToString();
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void EndTimer()
    {
        timerStarted = false;
        winPanel.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
