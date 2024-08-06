using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    SceneMan scene;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        scene = FindObjectOfType<SceneMan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPauseMenu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        scene.RestartScene();
    }
}
