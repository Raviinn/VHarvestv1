using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManagerFinal : MonoBehaviour
{
    public bool isplanted, isInRange; // checks if plot has been planted on
    SpriteRenderer plant;
    int plantstage = 0;
    float timer;
    FarmManager fm;
    public Color availColor;
    public Color unavailColor;
    SpriteRenderer plot;
    public int dayCounter = 1;
    public int plantDeath;
    public bool isDead;
    public bool isWatered;
    public bool isHarvesting;
    RandomEventManager randomEvent;
    private AudioSource audio;

    //plant object attributes
    public PlantObj selectedPlant;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        isplanted = false;
        isDead = false;
        isWatered = false;
        isHarvesting = false;
        plot = GetComponent<SpriteRenderer>();
        availColor = Color.yellow;
        unavailColor = Color.red;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isplanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantstage < selectedPlant.plantstages.Length - 1)
            {
                timer = selectedPlant.time;
                plantstage++;
                UpdatePlant();
            }

        }
        */


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isplanted)
            {
                if (isInRange && isDead &&  !fm.isPlanting)
                {
                    RemovePlant();
                }

                else if (isInRange && plantstage == selectedPlant.plantstages.Length - 2 && !fm.isPlanting && !isDead)
                {
                    Harvest();
                    isHarvesting=true;
                }
                
            }
            else 
            {
                if (isInRange && fm.isPlanting && fm.money >= fm.selectedPlant.plant.buyPrice && !isHarvesting)
                {
                    Plant(fm.selectedPlant.plant);
                    isWatered = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isplanted)
            {
                if (!isDead && isInRange && plantstage <= selectedPlant.plantstages.Length - 1)
                {
                    audio.Play();
                    WaterPlant();
                }
                
            }
        }

    }


    void Harvest()
    {
        fm.SellTransaction(selectedPlant);
        Debug.Log("Harvested");
        isplanted=false;
        plant.gameObject.SetActive(false);
        dayCounter = 1;
    }

    void RemovePlant()
    {
        Debug.Log("Removed");
        isplanted = false;
        plant.gameObject.SetActive(false);
        dayCounter = 1;
        isDead=false;
    }

    void WaterPlant()
    {
        isWatered = true;
        Debug.Log("Watered");
        plantDeath = 0;
    }

    void Plant(PlantObj newPlant)
    {
        selectedPlant = newPlant;
        fm.BuyTransaction(selectedPlant);
        Debug.Log("Planted");
        plantstage = 0;
        isplanted = true;
        UpdatePlant();
        plant.gameObject.SetActive(true);
    }

    public bool CheckPlantGrowth()
    {
        if (isplanted && !isDead)
        {
            if (dayCounter == selectedPlant.growdaysofPlant && plantstage < selectedPlant.plantstages.Length - 2 && isWatered) //plant sprite will update 
            {
                Debug.Log("Update Plant");
                plantstage++;
                UpdatePlant();
                dayCounter = 1;
            }

            else if (plantstage <= selectedPlant.plantstages.Length - 2 && !isWatered)//plant sprite will not update and plant death counter increments
            {
                plantDeath++;
                if (plantDeath == 3)
                {
                    isDead  = true;
                    plantDeath = 0;
                    UpdateDeadPlant();
                }
            }

            else if (!isWatered)
            {
                dayCounter = 1;
            }

            else if (isWatered)
            {
                dayCounter++; 
            }
        }
        isWatered = false; // reset watered status
        return isHarvesting; // return if plant has been harvested
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantstages[plantstage];
    }

    void UpdateDeadPlant()
    {
        plant.sprite = selectedPlant.plantstages[selectedPlant.plantstages.Length - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;

            if (fm.isPlanting)
            {
                if (isplanted)
                {
                    Debug.Log("Unavailable");
                    plant.color = unavailColor;
                }
                else if(fm.selectedPlant.plant.buyPrice > fm.money)
                {
                    plot.color = unavailColor;  
                }

                else
                {
                    Debug.Log("Available");
                    plot.color = availColor;
                }
            }
            
            if(!fm.isPlanting)
            {
               if(plantstage == selectedPlant.plantstages.Length - 1 || isDead || !isWatered)
                    Debug.Log("Can be Watered");
                    plant.color = availColor;
                    plot.color = availColor;
                
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is out of range");
            plot.color = Color.white;
            plant.color = Color.white;
        }
    }
}
