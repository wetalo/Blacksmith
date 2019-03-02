using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PercentageValues
{
    public float percentValue;
    public int numHits;
}

public class PointManager : MonoBehaviour {

    public PercentageValues[] percentageHitValues;
    PercentageValues currentValue;
    int percentValueIndex = 0;
    public PointTracker[] pointTrackers;
    public SwordBlend blender;

    float currentPercent = 100;

    int totalBeatNodes;
    int totalHits;
    int totalFalseHits;
    int totalMisses;

    float blendAmount;
    float hitBlendValue;
    // Use this for initialization
    void Start () {
        CalculateHitBlendValue(percentValueIndex);
        CalculateTotals();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CalculateHitBlendValue(int index)
    {
        currentValue = percentageHitValues[index];

        hitBlendValue = currentValue.percentValue / ((float)currentValue.numHits);
    }

    void CalculateTotals()
    {
        totalBeatNodes = 0;
        foreach(PointTracker tracker in pointTrackers)
        {
            totalBeatNodes += tracker.totalBeats;
        }
    }

    public void AddPoint()
    {
        blendAmount += hitBlendValue;
        if(blendAmount > currentValue.percentValue)
        {
            percentValueIndex++;
            CalculateHitBlendValue(percentValueIndex);
        }
        blender.GoodHit(hitBlendValue);
    }
    public void AddFalseHit()
    {
        blender.BadHit(((float)100) / ((float)totalBeatNodes));
    }

    public void StartSong()
    {
        CalculateHitBlendValue(percentValueIndex);
        CalculateTotals();
    }
}
