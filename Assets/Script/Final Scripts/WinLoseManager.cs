using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseManager : MonoBehaviour
{
    public Text winLoseText;
    public GameObject winLosePanel;
    SceneMan scene;
    // Start is called before the first frame update
    void Start()
    {
        winLosePanel.SetActive(false);
        scene = FindObjectOfType<SceneMan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerWin()
    {
        winLosePanel.SetActive(true);
        Debug.Log("Player Win");
        winLoseText.text = "You Win!";
    }

    public void PlayerLose()
    {
        winLosePanel.SetActive(true);
        winLoseText.text = "You Lose!";
    }

    public void WinLoseCheck(int winLoseChecker)
    {
        switch (winLoseChecker)
        {
            case 0:
                PlayerLose(); 
                break;
            case 1:
                PlayerWin();
                break;
            default:
                break;
        }
    }

    public void ClosePanel()
    {
        winLosePanel.SetActive(false);
        scene.RestartScene();
        //call scene manager and restart scene
    }
}
