using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Crop")]

public class PlantObj : ScriptableObject
{
    public string plantName;
    public Sprite[] plantstages;
    public float time;
    public int buyPrice;
    public int sellPrice;
    public Sprite icon;
    public int growdaysofPlant;
    public int plantMarker;
}
