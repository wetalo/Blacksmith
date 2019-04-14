using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour

{
    public bool activated;

    public Material activatedMaterial;
    public Material inactiveMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        GetComponent<Renderer>().material = activatedMaterial;
        activated = true;
    }

    public void DeActivate()
    {
        GetComponent<Renderer>().material = inactiveMaterial;
        activated = false;
    }
}
