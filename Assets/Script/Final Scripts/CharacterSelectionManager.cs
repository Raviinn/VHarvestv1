using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject charSelectionPanel;
    CharacterManager characterManager;
    // Start is called before the first frame update
    void Start()
    {
        charSelectionPanel.SetActive(false);
        characterManager = FindObjectOfType<CharacterManager>();

        if (characterManager == null)
        {
            Debug.Log("Empty");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCharacterSelect()
    {
        charSelectionPanel.SetActive (true);
    }

    public void SelectCharacter1()
    {
        //Choose Character 1
        charSelectionPanel.SetActive(false);
        characterManager.ChooseCharacter(0);
    }

    public void SelectCharacter2()
    {
        //Choose Character 2
        charSelectionPanel.SetActive(false);
        characterManager.ChooseCharacter(1);
    }
}
