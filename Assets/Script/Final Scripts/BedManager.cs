using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BedManager : MonoBehaviour
{
    public bool isInRange = false, isHarvesting = false;
    public int dayCount;
    PlotManagerFinal[] plots;
    public EndOfDayManager eof;
    public int[] counter;
    int Itemtotal, tempHolder;
    SummaryItem[] summaryItem;
    int totalProfit;
    TotalCompute total;
    RandomEventManager randomEvent;
    FarmManager fm;
    public WinLoseManager wm;
    // Start is called before the first frame update
    void Start()
    {
        plots = FindObjectsOfType<PlotManagerFinal>();
        counter = new int[7];
        totalProfit = 0;
        dayCount = 0;
        randomEvent = FindObjectOfType<RandomEventManager>();
        fm = FindObjectOfType<FarmManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInRange && !fm.isPlanting)
            {
                //logic for checking win/lose
                if (dayCount == 50)
                {
                    if(fm.money >= 1000)
                    {
                        wm.PlayerWin();
                        Debug.Log("Player Win");
                        //win condition
                    }else 
                    {
                        wm.PlayerLose();
                        Debug.Log("Player Lose");
                        //lose conidition
                    }
                }else if (fm.money >= 1000)
                {
                    wm.PlayerWin();
                    //win condition
                }

                CounterCleanup();
                dayCount++;
                foreach (PlotManagerFinal plot in plots)
                {
                    CheckPlots(plot);
                }
                Debug.Log("Day " + dayCount);
                eof.OpenEndOfDay();
                summaryItem = FindObjectsOfType<SummaryItem>();
                total = FindObjectOfType<TotalCompute>();
                UpdateSummaryList();
                randomEvent.ResetLaptop();
                randomEvent.CheckGenerateEvent();
                

            }
        }
    }

    private void ResetSummaryList(PlotManagerFinal plot)
    {
        for (int x = 0; x < summaryItem.Length; x++)
        {
            
        }
    }

    void UpdateSummaryList()
    {
        for (int x = 0; x < summaryItem.Length; x++)
        {
            if (randomEvent.acceptEvent)
            {
                tempHolder = randomEvent.ComputeNewSellPrice(summaryItem[x].plant);
            }
            else
            {
                tempHolder = summaryItem[x].plant.sellPrice;
            }

                summaryItem[x].priceTxt.text = "$ " + (tempHolder * counter[x]);
                totalProfit = totalProfit + (tempHolder * counter[x]);
        }
        total.ComputeTotal(totalProfit);
        totalProfit = 0;

    }
    void CounterCleanup()
    {
        for (int x = 0; x < 7; x++)
        {
            counter[x] = 0;
        }
    }
    void CheckPlots(PlotManagerFinal plot)
    {
        isHarvesting = plot.CheckPlantGrowth();
        if (isHarvesting)
        {
            switch (plot.selectedPlant.plantMarker)
            {
                case 0:
                    counter[0]++;
                    break;
                case 1:
                    counter[1]++;
                    break;
                case 2:
                    counter[2]++;
                    break;
                case 3:
                    counter[3]++;
                    break;
                case 4:
                    counter[4]++;//Eggplant
                    break;
                case 5:
                    counter[5]++;//Onion
                    break;
                case 6:
                    counter[6]++;//Tomato
                    break;
                default:
                    break;
            }
            plot.isHarvesting = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            
        }
    }
}
