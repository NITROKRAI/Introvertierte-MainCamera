using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePillar : MonoBehaviour
{
    public float RotationSpeed;
    public bool IsActivated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsActivated)
        {
            this.transform.Rotate(new Vector3(0, RotationSpeed, 0) * Time.fixedDeltaTime);
        }
    }
}
