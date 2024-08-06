using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCompute : MonoBehaviour
{
    public Text totalProfit;
   

    public void ComputeTotal(int totalValue)
    {
        totalProfit.text = "$ " + totalValue;
    }
}
