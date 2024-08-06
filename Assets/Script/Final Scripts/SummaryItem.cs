using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryItem : MonoBehaviour
{
    public PlantObj plant;
    public Text nameText;
    public Text priceTxt;
    public Image icon;
    FarmManager fm;
    // Start is called before the first frame update
    void Start()
    {
        InitializeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeUI()
    {
        nameText.text = plant.name;
        priceTxt.text = plant.buyPrice.ToString();
        icon.sprite = plant.icon;
    }

    void UpdateSummary(PlantObj selectedPlant)
    {

    }
}
