using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFarm : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D player)
    {

        if (player.tag == "Player")
        {
            Debug.Log("Farm");
            player.transform.position = new Vector3(-7, -2, 0);
            Camera.main.transform.position = new Vector3(-4, 0, -10);
        }
    }
}
