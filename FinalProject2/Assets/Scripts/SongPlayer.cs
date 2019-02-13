using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour {
    
    public MusicPlayer player;

    public Beat beat;
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

        beat.StartSong();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HammerHead")
        {
            PlaySong();
        }
    }
}
