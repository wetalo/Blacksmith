using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using SonicBloom.Koreo.Players;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    public GameEvent beatHit;
    SimpleMusicPlayer smp;

    List<KoreographyEvent> events;


    public List<IndicatorManager> indicatorManagers;
    public Koreography koreoGraphy;

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

    private void Start()
    {
        smp = GetComponent<SimpleMusicPlayer>();
    }

    public void SetKoreography(AudioClip clip, Koreography koreography)
    {
        //Koreographer.Instance.ClearEventRegister();
        this.koreoGraphy = koreography;
        GetComponent<AudioSource>().clip = clip;

        smp.LoadSong(koreography, 0, false);
        Koreographer.Instance.LoadKoreography(koreography);
        string[] eventIds = koreography.GetEventIDs();
       /* foreach(string eventId in eventIds)
        {
            if(eventId != "Beats")
            {
            Koreographer.Instance.RegisterForEvents(eventId, OnMusicalHit);
            }
        }*/
        Koreographer.Instance.RegisterForEvents("Beats", OnBeatHit);

        
        

    }

    public void OnMusicalHit(KoreographyEvent evt)
    {
        Debug.Log(evt.ToString());
    }

    public void OnBeatHit(KoreographyEvent evt)
    {
        beatHit.Raise();
        foreach(IndicatorManager manager in indicatorManagers)
        {
            manager.BeatIterate();
        }
    }

    public int GetCurrentTime()
    {
        return koreoGraphy.GetLatestSampleTime();
    }
}
