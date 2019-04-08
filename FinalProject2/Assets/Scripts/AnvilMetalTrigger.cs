using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilMetalTrigger : MonoBehaviour {

    public Transform metalSongLocation;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "SongMetal" && !other.GetComponent<OVRGrabbable>().isGrabbed)
        {
            other.transform.position = metalSongLocation.position;
            other.transform.rotation = metalSongLocation.rotation;
        }
    }
}
