using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveHome : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D player)
    {

        if(player.tag == "Player")
        {
            Debug.Log("Home");
            player.transform.position = new Vector3(-29, -3, 0);
            Camera.main.transform.position = new Vector3(-36, 0, -10);
        }
    }
}
