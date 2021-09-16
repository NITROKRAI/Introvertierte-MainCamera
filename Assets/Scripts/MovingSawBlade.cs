using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSawBlade : MonoBehaviour
{
    Vector3 SawTarget;
    public GameObject Endpoint;
    public float TravelTime;
    // Start is called before the first frame update
    void Start()
    {
        SawTarget = Endpoint.transform.position;
        transform.LeanMoveLocal(SawTarget, TravelTime).setEaseInOutQuad().setLoopPingPong();
    }
}
