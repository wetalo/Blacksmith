using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

    public float beatsPerMinute;
    float timeBetweenBeats;

    public Material red;
    public Material green;

    Renderer renderer;

    float timer;

    bool isOff;
    AudioSource sound;

    public float timeToLight = 0.1f;
    float soundLength;
    bool playedSound = false;

    public Transform targetCircle;
    public Transform expandingCircle;

    Vector3 targetScale;
    Vector3 initialScale;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        timer = 0f;
        sound = GetComponent<AudioSource>();
        isOff = true;
        targetScale = targetCircle.localScale;
        initialScale = expandingCircle.localScale;

        soundLength = sound.clip.length;
	}
	
	// Update is called once per frame
	void Update () {
        timeBetweenBeats = 1/ ( beatsPerMinute / 60f);
        timer += Time.deltaTime;
        if(timer > timeBetweenBeats)
        {
            timer = timeBetweenBeats;
        }
        
        expandingCircle.localScale = initialScale + ((targetScale - initialScale) * (timer / timeBetweenBeats));
        Debug.Log("BPM : :" + beatsPerMinute + " expandingCircle.localScale: " + expandingCircle.localScale.x + "," + expandingCircle.localScale.y + "," + expandingCircle.localScale.z );
        if(timer >= (timeBetweenBeats - (soundLength/2)) && !playedSound)
        {
            sound.Play();
            playedSound = true;
        }

        if (timer >= timeBetweenBeats)
        {
            timer = 0f;
            isOff = false;
            playedSound = false;
           // renderer.material = green;
        }

        if (!isOff)
        {
            if(timer > timeToLight)
            {
                isOff = true;
               // renderer.material = red;
            }
        }

	}
}
