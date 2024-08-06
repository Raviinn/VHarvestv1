using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterManager : MonoBehaviour
{
    public GameObject playerChar;
    PlantStoreManager storeManager;
    [SerializeField] public float movespeed;
    float x, y;
    public Rigidbody2D rb;
    Animator animate;
    SpriteRenderer playerSprite;
    public RuntimeAnimatorController[] controller;
    public Sprite[] playerIcon;
    public PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        storeManager = FindObjectOfType<PlantStoreManager>();
        animate = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * movespeed;
        y = Input.GetAxis("Vertical") * movespeed;
        rb.velocity = new Vector2 (x, y);

        if (Input.GetKeyDown(KeyCode.W))
        {
            animate.SetInteger("State", 1);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animate.SetInteger("State", 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animate.SetInteger("State", 2);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animate.SetInteger("State", 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animate.SetInteger("State", 3);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animate.SetInteger("State", 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animate.SetInteger("State", 4);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animate.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseManager.ShowPauseMenu();
        }
    }

    public void ChooseCharacter(int choice)
    {
        switch (choice)
        {
            case 0:
                playerSprite.sprite = playerIcon[0];
                animate.runtimeAnimatorController = controller[0];
                break;
            case 1:
                playerSprite.sprite = playerIcon[1];
                animate.runtimeAnimatorController = controller[1];
                break;
            default:
                break;
        }
    }

}
