<<<<<<< Updated upstream:Assets/Scripts/TrapActivater.cs
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivater : MonoBehaviour
{
    private Transform parent;
    private Vector3 idlePosition;
    private Vector3 activatedPosition;
    private bool isActivated = false;
    private float activationDuration = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        idlePosition = new Vector3(parent.position.x, parent.position.y, parent.position.z);
        activatedPosition = new Vector3(parent.position.x, parent.position.y + (-parent.position.y), parent.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            /*
            Debug.Log("Player in Trap");
            parent.position = new Vector3(parent.position.x,parent.position.y + (-parent.position.y),parent.position.z);
            */

            StartCoroutine(GetTemporarilyActivated());
        }
    }

    private IEnumerator GetTemporarilyActivated()
    {
        Debug.Log("Trap is activated");
        isActivated = true;
        parent.position = activatedPosition;

        yield return new WaitForSeconds(activationDuration);

        parent.position = idlePosition;
        isActivated = false;
        Debug.Log("Trap isn't activated");
    }
}
>>>>>>> Stashed changes:Assets/Scripts/Map/TrapActivater.cs
