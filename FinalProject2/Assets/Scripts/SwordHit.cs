using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour {


    public GameObject hitParticle;

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

            GameObject hitInstance = GameObject.Instantiate(hitParticle, other.ClosestPointOnBounds(transform.position), Quaternion.identity);
            hitInstance.transform.rotation = Quaternion.LookRotation(transform.up,Vector3.up);

        }
    }
}
