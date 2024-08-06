using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDayManager : MonoBehaviour
{
    public GameObject panelEOD, panelSummary;
     
    // Start is called before the first frame update
    void Start()
    {
        panelEOD.SetActive(false);
        panelSummary.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseEndOfDay()
    {
        panelEOD.SetActive(false);
    }
    public void OpenEndOfDay()
    {
            panelEOD.SetActive(true);
            panelSummary.SetActive(true);
    }
}
