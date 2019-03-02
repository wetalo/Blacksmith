using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour {
    
    public MusicPlayer player;
    public PointManager PM;

    public Beat beat1;
    public Beat beat2;
    public Beat beat3;
    bool isPlayingSong;

    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayingSong)
        {
            if (!player.isPlayingSong)
            {
                isPlayingSong = false;
            }

            timer += Time.deltaTime;
        }
	}

    public void PlaySong()
    {
        //ScriptableObject.CreateInstance("SongNodes");
        player.StartPlayingMusic();
        isPlayingSong = true;

        beat1.StartSong();
        beat2.StartSong();
        beat3.StartSong();

        PM.StartSong();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HammerHead")
        {
            PlaySong();
        }
    }
}
