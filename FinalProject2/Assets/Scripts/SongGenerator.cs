using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongGenerator : MonoBehaviour {

    public SongNodes songNodesToModify;
    public MusicPlayer player;


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

    public void TakeHit()
    {
        if (isPlayingSong)
        {
            SongNode node = new SongNode();
            node.floatTimestamp = timer;

            songNodesToModify.nodes.Add(node);
        }
    }

    public void CreateSong()
    {
        //ScriptableObject.CreateInstance("SongNodes");
        player.StartPlayingMusic();
        timer = 0f;
        isPlayingSong = true;

        songNodesToModify.nodes = new List<SongNode>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HammerHead")
        {
            CreateSong();
        }
    }
}
