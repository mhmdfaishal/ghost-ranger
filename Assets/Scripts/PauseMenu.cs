using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;
    AudioSource audioSource;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(ExitGame);
        Time.timeScale = 1;
        pause.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        audioSource.mute = true;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        audioSource.mute = false;
    }
    
    public void ExitGame()
    {
        SceneManager.LoadScene("MenusScene");
    }
}
