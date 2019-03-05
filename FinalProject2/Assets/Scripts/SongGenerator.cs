using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
struct EditableNode
{
    public SongNodes beat;
    public bool edit;
}
public class SongGenerator : MonoBehaviour {

    [SerializeField]
    EditableNode beat1;
    [SerializeField]
    EditableNode beat2;
    [SerializeField]
    EditableNode beat3;
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

    public void TakeHit(SwordHitboxType hitboxIndex)
    {
        if (isPlayingSong)
        {
            SongNodes songNodesToModify = new SongNodes();
            switch (hitboxIndex)
            {
                case SwordHitboxType.Box1:
                    if (beat1.edit)
                    {
                        songNodesToModify = beat1.beat;
                    } else
                    {
                        return;
                    }
                    break;
                case SwordHitboxType.Box2:
                    if (beat2.edit)
                    {
                        songNodesToModify = beat2.beat;
                    }
                    else
                    {
                        return;
                    }
                    break;
                case SwordHitboxType.Box3:
                    if (beat3.edit)
                    {
                        songNodesToModify = beat3.beat;
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
            
            SongNode node = new SongNode();
            node.floatTimestamp = timer;

            songNodesToModify.nodes.Add(node);
        }
    }

    public void CreateSong()
    {
        if (beat1.edit)
        {
            EditorUtility.SetDirty(beat1.beat);
            beat1.beat.nodes = new List<SongNode>();
        }

        if (beat2.edit)
        {
            EditorUtility.SetDirty(beat2.beat);
            beat2.beat.nodes = new List<SongNode>();
        }

        if (beat3.edit)
        {
            EditorUtility.SetDirty(beat3.beat);
            beat3.beat.nodes = new List<SongNode>();
        }

        //ScriptableObject.CreateInstance("SongNodes");
        player.StartPlayingMusic();
        timer = 0f;
        isPlayingSong = true;



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HammerHead")
        {
            CreateSong();
        }
    }
}
