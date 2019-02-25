using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour {


    public GameObject hitParticle;
    public PointTracker tracker;
    public SongGenerator generator;
    public SwordHitboxType hitboxIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HammerHead")
        {
            tracker.TakeHit();
            generator.TakeHit(hitboxIndex);
            GameObject hitInstance = GameObject.Instantiate(hitParticle, other.ClosestPointOnBounds(transform.position), Quaternion.identity);
            hitInstance.transform.rotation = Quaternion.LookRotation(transform.up,Vector3.up);

        }
    }
}
