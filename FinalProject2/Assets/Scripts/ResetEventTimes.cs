using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using SonicBloom.Koreo;
using SonicBloom.Koreo.Players;
using UnityEngine;

public class ResetEventTimes : EditorWindow
{

    public KoreographyTrack trackToEdit;
    public int timeToMove;

    [MenuItem("Window/Song Event Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<ResetEventTimes>("ResetEventTimes");
    }

    void OnGUI()
    {

        trackToEdit = EditorGUILayout.ObjectField("", trackToEdit, typeof(KoreographyTrack), true) as KoreographyTrack;
        timeToMove = EditorGUILayout.DelayedIntField(timeToMove);

        if (GUILayout.Button("Move events"))
        {
            if (trackToEdit == null)
            {
                ShowNotification(new GUIContent("No object selected for Edit"));
            }
            else
            {
                MoveEvents();
            }
        }

        if (GUILayout.Button("Save Changes"))
        {
            if (nodes == null)
            {
                ShowNotification(new GUIContent("No object selected to save"));
            }
            else
            {
                SaveNodeChanges();
            }
        }

    }

   

    void MoveEvents()
    {
        foreach(KoreographyEvent koreoEvent in trackToEdit.GetAllEvents())
        {

        }
    }
  

    void SaveNodeChanges()
    {
        EditorUtility.SetDirty(nodes);

        List<SongNode> songnodeList = new List<SongNode>();
        for (int i = 0; i < curve.keys.Length; i++)
        {
            Keyframe currentKey = curve.keys[i];
            SongNode node = new SongNode();
            node.floatTimestamp = currentKey.time;
            songnodeList.Add(node);
        }

        nodes.nodes = songnodeList;

    }
