using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTracker : MonoBehaviour {

    private int score;
    private int misses;
    private int falseHits;

    bool isValid;
    bool tookHit;
    public Text pointTrackerText;

    public int totalBeats;
    public SwordBlend blender;

	void Start() {
        score = 0;
        misses = 0;
        falseHits = 0;
        UpdateUI();
    }

    void AddPoint()
    {
        score++;
        blender.GoodHit(((float)score) / ((float)totalBeats));
    }

    void AddMiss()
    {
        misses++;
    }

    void AddFalseHit()
    {
        falseHits++;
        blender.BadHit(((float)falseHits) / ((float)totalBeats));
    }


    public void BeginHitTime()
    {
        isValid = true;
        tookHit = false;
    }

    public void EndHitTime()
    {
        isValid = false;
        if (!tookHit)
        {
            AddMiss();
        }

        tookHit = false;
        UpdateUI();
    }

    public void TakeHit()
    {
        if (isValid)
        {
            AddPoint();
        } else
        {
            AddFalseHit();
        }
        tookHit = true;
        UpdateUI();
    }

    void UpdateUI()
    {
        pointTrackerText.text = "Hits: " + score + "\n" + "False hits: " + falseHits + "\n" + "Misses: " + misses;
    }
}
