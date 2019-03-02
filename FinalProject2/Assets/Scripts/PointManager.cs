﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    Text debugText;
    // Use this for initialization
    void Start () {
        debugText = GameObject.Find("DebugText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        PrintUI();

    }

    void CalculateHitBlendValue(int index)
    {
        if(percentageHitValues.Length > index)
        {
            currentValue = percentageHitValues[index];

            hitBlendValue = currentValue.percentValue / ((float)currentValue.numHits);
        } else
        {
            hitBlendValue = (100- currentValue.percentValue) / ((float)(totalBeatNodes - currentValue.numHits));
        }
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
        totalHits++;
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
        percentValueIndex = 0;
        blendAmount = 0;
        totalHits = 0;

        CalculateHitBlendValue(percentValueIndex);
        CalculateTotals();
    }

    void PrintUI()
    {
        debugText.text =
            "totalBeatNodes: " + totalBeatNodes + "\n" +
            "totalHits: " + totalHits + "\n" +
            "blendAmount: " + blendAmount + "\n" +
            "hitBlendValue: " + hitBlendValue + "\n" +
            "currentValue.percentValue: " + currentValue.percentValue;
    }
}
