﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour {

    public Transform targetCircle;
    float timer;
    public float timeTillBeat = 1;
    public float leeWay;
    float expansionAmount;
    Vector3 targetScale;
    Vector3 initialScale;

    // Use this for initialization
    void Start () {
        initialScale = transform.localScale;
        targetScale = new Vector3(1, 1, 1);
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        expansionAmount = (timer / timeTillBeat);
        if(expansionAmount > 1)
        {
            expansionAmount = 1;
        }
        transform.localScale = initialScale + ((targetScale - initialScale) * expansionAmount);

        if(timer > timeTillBeat - (leeWay / 2))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        if(timer >= timeTillBeat + (leeWay/2))
        {
            Destroy(gameObject);
        }
    }
}
