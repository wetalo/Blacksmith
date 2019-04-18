using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class IndicatorManager : MonoBehaviour
{
    public bool autoActivate;
    public Indicator[] indicators;
    List<KoreographyEvent> laneEvents = new List<KoreographyEvent>();
    int laneEventIndex = 0;
    int timeBeforeSpawn;

    private void Update()
    {
        
    }

    void CheckSpawnNext()
    {
        if ((laneEvents[laneEventIndex].StartSample-timeBeforeSpawn) <= Koreographer.Instance.GetMusicSampleTime())
        {
            ActivateInitialIndicator();
            laneEventIndex++;
        }
    }

    public void BeatIterate()
    {
        bool foundActivated = false;
        for(int i= indicators.Length-1; i>=0; i--)
        {
            if (i != indicators.Length - 1)
            {
                if (indicators[i].activated)
                {
                    foundActivated = true;
                    indicators[i].DeActivate();
                    indicators[i + 1].Activate();
                    //break;
                }
            }
            else if (i == indicators.Length - 1)
            {
                if (indicators[i].activated)
                {
                    foundActivated = true;
                    indicators[i].DeActivate();
                }
            }
        }
        if (!foundActivated && autoActivate)
        {
            indicators[0].Activate();
        }

        CheckSpawnNext();
    }

    public void ActivateInitialIndicator()
    {
        indicators[0].Activate();
    }

    public void SetLaneEvents(KoreographyTrackBase track)
    {

        timeBeforeSpawn = GameManager.instance.spawnEarlyInSeconds * GameManager.instance.SampleRate; 
        this.laneEvents = track.GetAllEvents();
        laneEventIndex = 0;
    }
}
