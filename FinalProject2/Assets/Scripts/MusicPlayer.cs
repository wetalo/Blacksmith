using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioSource audioSource;
    public bool isPlayingSong;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayingSong)
        {
            if (!audioSource.isPlaying)
            {
                isPlayingSong = false;
            }
        }
	}

    public void StartPlayingMusic()
    {
        audioSource.Play();
        isPlayingSong = true;
    }
}
