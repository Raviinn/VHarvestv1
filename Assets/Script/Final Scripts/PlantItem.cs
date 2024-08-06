using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObj plant;
    public Text nameText;
    public Text priceTxt;
    public Image icon;
    public Text buttonText;
    public Image btnImg;
    FarmManager fm;
    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
    }

    public void BuyPlant()
    {
        Debug.Log("Bought " + plant.plantName);
        fm.SelectPlant(this);
    }

   void InitializeUI()
    {
        nameText.text = plant.name;
        priceTxt.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }

}
