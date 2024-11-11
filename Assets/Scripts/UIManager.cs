using flyingMonster;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("FinishPanel")]
    public GameObject finishPanel;
    public TextMeshProUGUI scoreText;
    [Header("StartPanel")]
    public GameObject startPanel;
    [Header("PuasePanel")]
    public GameObject puasePanel;
    [SerializeField] GameObject audio_btn;
    [SerializeField] GameObject audioMute_btn;

    public TextMeshProUGUI time_text;
    public bool isAudio = true;

    private void Awake()
    {
        Instance = this;
    }
    public void AudioButton_Switch()
    {
        if (isAudio)
        {
            audio_btn.SetActive(false);
            audioMute_btn.SetActive(true);
            AudioManager.instance.CloseAllAudio();
            isAudio = false;
        }
        else 
        {
            audio_btn.SetActive(true);
            audioMute_btn.SetActive(false);
            AudioManager.instance.OpenAllAudio();
            isAudio = true;
        }
    }
    public void UpdateTimeText()
    {
        time_text.text = Mathf.CeilToInt(TimeManager.instance.time).ToString();
    }
    public void StartPanel_Switch(bool state)
    {
        startPanel.SetActive(state);
    }
    public void PuasePanel_Switch(bool state)
    {
        puasePanel.SetActive(state);
        if (state)
        {
            TimeManager.instance.Puase();
        }
        else 
        {
            StartCoroutine(TimeManager.instance.Unpuase());
        }
    }
    public void ShowScore(int _score)
    {
        finishPanel.SetActive(true);
        scoreText.text = _score.ToString();
    }
}
