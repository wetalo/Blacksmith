using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class IndicatorManager : MonoBehaviour
{
    public bool autoActivate;
    public Indicator[] indicators;
    public KoreographyTrack track;

    private void Update()
    {
        
    }

    void CheckSpawnNext()
    {
        int samplesToTarget = GetSpawnSampleOffset();

        int currentTime = ;

        // Spawn for all events within range.
        while (pendingEventIdx < laneEvents.Count &&
               laneEvents[pendingEventIdx].StartSample < currentTime + samplesToTarget)
        {
            KoreographyEvent evt = laneEvents[pendingEventIdx];

            NoteObject newObj = gameController.GetFreshNoteObject();
            newObj.Initialize(evt, color, this, gameController);

            trackedNotes.Enqueue(newObj);

            pendingEventIdx++;
        }
    }

    public void BeatIterate()
    {
        bool foundActivated = false;
        for(int i=0; i<indicators.Length; i++)
        {
            if (i != indicators.Length - 1)
            {
                if (indicators[i].activated)
                {
                    foundActivated = true;
                    indicators[i].DeActivate();
                    indicators[i + 1].Activate();
                    break;
                }
            }
            else
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
    }

    public void ActivateInitialIndicator()
    {
        indicators[0].Activate();
    }
}
