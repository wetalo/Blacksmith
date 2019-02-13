using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

    public float beatsPerMinute;
    float timeBetweenBeats;
    public float delayBeforeSound;

    public Material red;
    public Material green;

    Renderer renderer;

    float timer;

    bool isOff;
    AudioSource sound;

    public float leeWay = 0.1f;
    bool playedSound = false;
    
    public GameObject expandingCirclePrefab;
    public Transform targetCircle;
    

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        timer = 0f;
        sound = GetComponent<AudioSource>();
        isOff = true;
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            MakeExpander();
            timer = 0f;
        }

	}

    public void MakeExpander()
    {
        GameObject.Instantiate(expandingCirclePrefab,targetCircle,false).GetComponent<Expander>().targetCircle = transform;
    }

    //Deprecated code, keeping for sentimental value <3
    void BeatRhythm()
    {
        //timeBetweenBeats = 1 / (beatsPerMinute / 60f);
        //timer += Time.deltaTime;
        //if (timer > timeBetweenBeats)
        //{
        //    timer = timeBetweenBeats;
        //}

        //expandingCircle.localScale = initialScale + ((targetScale - initialScale) * (timer / timeBetweenBeats));
        //Debug.Log("BPM : :" + beatsPerMinute + " expandingCircle.localScale: " + expandingCircle.localScale.x + "," + expandingCircle.localScale.y + "," + expandingCircle.localScale.z);
        //if (timer >= (timeBetweenBeats - delayBeforeSound) && !playedSound)
        //{
        //    sound.Play();
        //    playedSound = true;
        //}

        //if (timer >= timeBetweenBeats)
        //{
        //    timer = 0f;
        //    isOff = false;
        //    playedSound = false;
            // renderer.material = green;
        //}

        //if (!isOff)
        //{
        //    if (timer > timeToLight)
        //    {
        //        isOff = true;
                // renderer.material = red;
        //    }
        //}
    }
}
