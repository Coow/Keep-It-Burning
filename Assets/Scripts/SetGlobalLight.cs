using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class SetGlobalLight : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D light;
    public float strength;
    
    // Start is called before the first frame update
    void Start()
    {
    light.intensity = strength;    
    }

}
