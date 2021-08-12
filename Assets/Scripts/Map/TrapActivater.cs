using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivater : MonoBehaviour
{
    Transform parent;
    private bool isActivated = false;
    private Vector3 defaultPosition;
    private Vector3 activPosition;

    [SerializeField] private float activationDuration;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        defaultPosition = new Vector3(parent.position.x, parent.position.y, parent.position.z);
        activPosition = new Vector3(parent.position.x, parent.position.y + (-parent.position.y), parent.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(isActivated)
            {
                return;
            }
            Debug.Log("Player in Trap");
            StartCoroutine(GetTemporarilyActivated());
            //parent.position = new Vector3(parent.position.x,parent.position.y + (-parent.position.y),parent.position.z);
        }
    }

    private IEnumerator GetTemporarilyActivated()
    {
        Debug.Log("Trap is activ");
        isActivated = true;
        parent.position = activPosition;

        yield return new WaitForSeconds(activationDuration);

        parent.position = defaultPosition;
        isActivated = false;
        Debug.Log("Trap is inactiv");
    }
}
