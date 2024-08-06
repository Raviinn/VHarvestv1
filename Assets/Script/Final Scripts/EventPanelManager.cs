using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPanelManager : MonoBehaviour
{
    public GameObject eventPanel;
    public Text eventTitle, eventDesc;
    // Start is called before the first frame update
    void Start()
    {
        eventPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPanel(int eventChoice)
    {
        switch (eventChoice)
        {
            case 0:
                eventTitle.text = "Sinigang Competition";
                eventDesc.text = "It's the Sinigang Competition tomorrow! Ready your taste buds to taste the most delicious and the most sour " +
                    "Sinigang in the region. In demand crops include Eggplant, Radish, Tomato, and Onions. There will also be crops " +
                    "that will not sell well during this time so prepare your harvest well during this event!";
                break;
            case 3:
                eventTitle.text = "Samgyupsal Fair";
                eventDesc.text = "Calling all meat eaters! It's the samgyupsal fair tomorrow! Lettuce and radish will be complements to " +
                    "our local meats. Be sure to come with an empty stomach, as this will be an eat all you can!!";
                break;
            case 6:
                eventTitle.text = "Soup Festival";
                eventDesc.text = "Warm your bellies with our region's famous Squash soup! Tomorrow will be our Soup Festival. Taste different variations of this soup, as well as" +
                    "soups made from other vegetables. Perfect festival for a cold rainy weather!";
                break;
            case 9:
                eventTitle.text = "DIY Spaghetti Competition";
                eventDesc.text = "Everybody's favorite childhood food, spaghetti! Tomorrow we will hold a DIY Spaghetti competition, " +
                    "meaning, there will be a high demand for tomatoes!! For our farmers, be sure to have a lot of tomatoes ready for" +
                    "harvest by then!";
                break;
            case 12:
                eventTitle.text = "Valley Fair";
                eventDesc.text = "Here is the day for our beloved farmers! Tomorrow we will hold the Valley fair where we get to showcase" +
                    "our produce to tourists and visitors! All vegetables will have a high demand so make sure to grow the most expensive" +
                    "crops for a better profit!";
                break;

            default:
                break;

        }
    }

    public void OpenPanel()
    {
        eventPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        eventPanel.SetActive(false);
    }


}
