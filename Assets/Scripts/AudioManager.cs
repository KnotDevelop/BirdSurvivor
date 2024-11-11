using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource background;
    [SerializeField] AudioSource fire;
    [SerializeField] AudioSource swipe;
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource dead;
    [SerializeField] AudioSource gameOver;
    private void Awake()
    {
        instance = this;
    }
    public void Play_Background() 
    {
        background.Play();
    }
    public void Stop_Background()
    {
        background.Stop();
    }
    public void Play_GameOver()
    {
        gameOver.Play();
    }
    public void Play_Click() 
    {
        click.Play();
    }
    public void Play_Swipe() 
    {
        swipe.Play();
    }
    public void Play_Fire()
    {
        fire.Play();
    }
    public void Play_Dead() 
    {
        dead.Play();
    }
    public void OpenAllAudio() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioVolume>().OpenSound();
        }
    }
    public void CloseAllAudio()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioVolume>().CloseSound();
        }
    }
}
