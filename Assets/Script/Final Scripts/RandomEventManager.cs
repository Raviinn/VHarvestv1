using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    public int daysOfEventCounter, eventChooser;
    public bool hasAnEvent; //Check if an event is underway
    public bool acceptEvent; // Player accepts event
    bool isInRange;
    public Sprite[] eventStatus; //Will contain the Sprites that will change when an event takes place
    public SpriteRenderer laptop;
    public GameObject notification; //Exclamation point
    public int newPlantPrice;
    public EventPanelManager eventPanel;
    // Start is called before the first frame update
    void Start()
    {
        daysOfEventCounter = 5;
        eventChooser = 0;
        laptop = GetComponent<SpriteRenderer>();
        hasAnEvent = false;
        isInRange = false;
        acceptEvent = false;
        notification.SetActive(false);
        newPlantPrice = 0; 

        if (eventPanel == null)
        {
            Debug.LogError("EventPanelManager not found in the scene!");
        }
        else
        {
            Debug.Log("Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInRange && hasAnEvent)
            {
                StartEvent();
                ResetLaptop();
                eventPanel.SelectPanel(eventChooser);
                eventPanel.OpenPanel();
            }
        }
    }

    public void CheckGenerateEvent()
    {
        if (!hasAnEvent)
        {
            eventChooser = Random.Range(0, 16);
            switch (eventChooser)
            {
                case 0:
                    Debug.Log("Chosen event " + eventChooser);
                    notification.SetActive (true);
                    laptop.sprite = eventStatus[1];
                    hasAnEvent = true;
                    break;
                case 3:
                    Debug.Log("Chosen event " + eventChooser);
                    notification.SetActive(true);
                    laptop.sprite = eventStatus[1];
                    hasAnEvent = true;
                    break;
                case 6:
                    Debug.Log("Chosen event " + eventChooser);
                    notification.SetActive(true);
                    laptop.sprite = eventStatus[1];
                    hasAnEvent = true;
                    break;
                case 9:
                    Debug.Log("Chosen event " + eventChooser);
                    notification.SetActive(true);
                    laptop.sprite = eventStatus[1];
                    hasAnEvent = true;
                    break;
                case 12:
                    Debug.Log("Chosen event " + eventChooser);
                    notification.SetActive(true);
                    laptop.sprite = eventStatus[1];
                    hasAnEvent = true;
                    break;
                default:
                    break;
            }
        }
        else if (acceptEvent && hasAnEvent) 
        {
            if (daysOfEventCounter > 1)
            {
                daysOfEventCounter--;
                Debug.Log(daysOfEventCounter + " day(s) remaining on the event!");
            }
            else
            {
                Debug.Log("Event is done");
                hasAnEvent = false;
                acceptEvent = false;
                notification.SetActive(false);
                daysOfEventCounter = 5;
            }
        }
            
    }


    public void StartEvent()
    {
        acceptEvent = true;
    }

    public void ResetLaptop()
    {
        laptop.sprite = eventStatus[0];
        notification.SetActive (false);
        hasAnEvent = acceptEvent;
      
    }

    public int ComputeNewSellPrice(PlantObj plant) // Computes updated price of plants during events
    {
        /*
         *  Tomato = 6
         *  Onion =5
            Eggplant =4
            Peanuts = 3
            Squash = 2
            Lettuce = 1
            Radish = 0

         */

        if (eventChooser == 0)//Sinigang Competition
        {
            if (plant.plantMarker == 6 || plant.plantMarker == 5)
            {
                Debug.Log("Increase in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice + 25;

            }
            else if (plant.plantMarker == 4 || plant.plantMarker == 0)
            {
                Debug.Log("Increase in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice + 10;
            }
            else if (plant.plantMarker == 3 || plant.plantMarker == 2)
            {
                Debug.Log("Decrease in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice - 10;
            }
        }
        else if (eventChooser == 3)//Samgyupsal Fair
        {
            if (plant.plantMarker == 1 || plant.plantMarker == 0)
            {
                Debug.Log("Increase in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice + 30;

            }

            else if (plant.plantMarker == 2)
            {
                Debug.Log("Decrease in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice - 5;
            }
        }
        else if (eventChooser == 6)//Soup Festival
        {
            if (plant.plantMarker == 2)
            {
                Debug.Log("Increase in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice + 20;

            }

            else if (plant.plantMarker == 0 || plant.plantMarker == 5 || plant.plantMarker == 6)
            {
                Debug.Log("Increase in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice + 10;
            }

            else if (plant.plantMarker == 3 || plant.plantMarker == 1)
            {
                Debug.Log("Decrease in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice - 10;
            }
        }
        else if (eventChooser == 9)//Spaghetti Festival
        {
            if (plant.plantMarker == 6)
            {
                Debug.Log("Increase in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice + 30;

            }

            else if (plant.plantMarker == 5)
            {
                Debug.Log("Increase in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice + 10;
            }

            else if (plant.plantMarker == 3 || plant.plantMarker == 1 || plant.plantMarker == 4)
            {
                Debug.Log("Decrease in price for " + plant.plantName);
                newPlantPrice = plant.sellPrice - 10;
            }
        }
        else if (eventChooser == 12)//Valley Fair
        {
            Debug.Log("Increase in price for all crops");
            newPlantPrice = plant.sellPrice + 10;
        }

            return newPlantPrice;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }
}
