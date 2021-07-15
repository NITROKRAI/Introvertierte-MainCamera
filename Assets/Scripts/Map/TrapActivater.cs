using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivater : MonoBehaviour
{
    Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player in Trap");
            parent.position = new Vector3(parent.position.x,parent.position.y + (-parent.position.y),parent.position.z);
        }
    }
}
