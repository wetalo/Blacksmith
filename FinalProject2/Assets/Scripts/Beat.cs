using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beat : MonoBehaviour {

    public float beatsPerMinute;
    float timeBetweenBeats;
    public float delayBeforeSound;

    public Material red;
    public Material green;

    Renderer renderer;

    float timer;

    bool isOn;
    AudioSource sound;

    public float leeWay = 0.1f;
    bool playedSound = false;
    
    public GameObject expandingCirclePrefab;
    public Transform targetCircle;

    public SongNodes songNodes;
    SongNode currentNode;
    int currentNodeIndex;
    float nextTimestamp;

    public Text nodeIndexText;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        timer = 0f;
        sound = GetComponent<AudioSource>();

        
	}

    void SetupNode(int nodeIndex)
    {
        currentNode = songNodes.nodes[nodeIndex];
        nextTimestamp = currentNode.floatTimestamp;

        nodeIndexText.text = "Node: " + (nodeIndex + 1);
    }

    public void StartSong()
    {
        timer = 0f;
        isOn = true;
        currentNodeIndex = 0;
        SetupNode(currentNodeIndex);
    }
	
	// Update is called once per frame
	void Update () {
        if (isOn)
        {
            timer += Time.deltaTime;
            if (timer >= nextTimestamp-1)
            {
                MakeExpander();
                currentNodeIndex++;
                SetupNode(currentNodeIndex);
            }
        }

	}

    public void MakeExpander()
    {
        Expander expander = GameObject.Instantiate(expandingCirclePrefab, targetCircle, false).GetComponent<Expander>();
        expander.targetCircle = transform;
        expander.leeWay = this.leeWay;
        expander.tracker = GetComponent<PointTracker>();
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
