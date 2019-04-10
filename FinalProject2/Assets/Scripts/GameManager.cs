using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    
    public void SetKoreography(AudioClip clip, Koreography koreography)
    {

        GetComponent<AudioSource>().clip = clip;
        

        GetComponent<Koreographer>().LoadKoreography(koreography);
        string[] eventIds = koreography.GetEventIDs();
        foreach(string eventId in eventIds)
        {
            Koreographer.Instance.RegisterForEvents(eventId, OnMusicalHit);
        }
        
    }

    public void OnMusicalHit(KoreographyEvent evt)
    {

    }
}
