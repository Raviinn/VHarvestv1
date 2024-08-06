using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantStoreManager : MonoBehaviour
{
    public GameObject plantStore;
    // Start is called before the first frame update
    void Start()
    {
        plantStore.SetActive(true);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateStoreManager()
    {
        plantStore.SetActive(false);
        Debug.Log("plantStore is deactivated.");
    }

    public void ActivateStoreManager()
    {    
        plantStore.SetActive(true);
        Debug.Log("plantStore is activated.");
        
    }
}
