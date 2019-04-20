﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorHitbox : MonoBehaviour
{
    public Indicator greenIndicator;
    public GameObject hitParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HammerHead" && greenIndicator.activated)
        {
            string handHoldingHammer = other.transform.parent.gameObject.GetComponent<OVRGrabbable>().grabbedBy.ToString();
            if (handHoldingHammer == "AvatarGrabberRight (OVRGrabber)")
            {
                ControllerManager.CM.StartVibration(1, 1, 0.1f, OVRInput.Controller.RTouch);
            }
            else if (handHoldingHammer == "AvatarGrabberLeft (OVRGrabber)")
            {
                ControllerManager.CM.StartVibration(1, 1, 0.1f, OVRInput.Controller.LTouch);
            }
            GameObject hitInstance = GameObject.Instantiate(hitParticle, other.ClosestPointOnBounds(transform.position), Quaternion.identity);
            hitInstance.transform.rotation = Quaternion.LookRotation(transform.up, Vector3.up);
        }
    }
}
