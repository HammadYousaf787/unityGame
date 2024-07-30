using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quiverScript : MonoBehaviour
{
    public MeshRenderer PLS;

    public void enable()
    {
        PLS.enabled = true;
    }
    public void disable()
    {
        PLS.enabled = false; ;
    }

    
}