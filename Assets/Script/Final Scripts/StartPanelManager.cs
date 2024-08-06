using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelManager : MonoBehaviour
{
    public GameObject startPanel;
    public CharacterSelectionManager charSelectPanel;
    public GameObject tutorialPanel;
    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        charSelectPanel.OpenCharacterSelect();
    }

    public void Tutorials()
    {
        startPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        //open tutorials
    }
}
