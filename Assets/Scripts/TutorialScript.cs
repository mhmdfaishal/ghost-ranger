using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject tutorial1;
    [SerializeField] private GameObject tutorial2;
    [SerializeField] private Button nextButton;

    private void Start()
    {
        nextButton.onClick.AddListener(NextTutorial);
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public void NextTutorial()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
    }

    
    
}
