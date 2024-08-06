using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectedPlant;
    public bool isPlanting;
    public int money;
    public Text moneyTxt;
    public Color buyColor = Color.white;
    public Color cancelColor = Color.red;
    RandomEventManager randomEvent;

    // Start is called before the first frame update
    void Start()
    {
        moneyTxt.text = "$" + money;
        isPlanting = false;
        randomEvent = FindObjectOfType<RandomEventManager>();
}

    public void SelectPlant (PlantItem newPlant)
    {
        if (selectedPlant == newPlant)
        {
            selectedPlant.buttonText.text = "Buy";
            selectedPlant.btnImg.color = buyColor;
            Debug.Log("Deselected " + selectedPlant.plant.plantName);
            selectedPlant = null;
            isPlanting = false;
        }
        else
        {
            if (selectedPlant != null)
            {
                selectedPlant.buttonText.text = "Buy";
                selectedPlant.btnImg.color = buyColor;
            }

            selectedPlant = newPlant;
            selectedPlant.buttonText.text = "Cancel";
            selectedPlant.btnImg.color = cancelColor;
            Debug.Log("Selected " + selectedPlant.plant.plantName);
            isPlanting = true;
        }
    }


    public void BuyTransaction(PlantObj plant)
    {
        money -= plant.buyPrice;
        moneyTxt.text = "$" + money;
    }

    public void SellTransaction(PlantObj plant)
    {
        if (randomEvent.acceptEvent)
        {
            Debug.Log("Display " + randomEvent.acceptEvent);
            money += randomEvent.ComputeNewSellPrice(plant);
        }
        else
        {
            money += plant.sellPrice;
        }
        moneyTxt.text = "$" + money;
    }
}
