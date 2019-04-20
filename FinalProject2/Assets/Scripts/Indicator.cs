﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour

{
    public bool activated;

    public Material activatedMaterial;
    public Material inactiveMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        GetComponent<Renderer>().material = activatedMaterial;
        activated = true;
        
        Debug.Log(gameObject.name + "  Activated   " + GameManager.instance.koreoGraphy.GetLatestSampleTime());
    }

    public void DeActivate()
    {
        GetComponent<Renderer>().material = inactiveMaterial;
        activated = false;
        Debug.Log(gameObject.name + "  DeActivated   " + GameManager.instance.koreoGraphy.GetLatestSampleTime());
    }
}
