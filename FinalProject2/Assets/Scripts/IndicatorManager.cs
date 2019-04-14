using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    public bool autoActivate;
    public Indicator[] indicators;

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
