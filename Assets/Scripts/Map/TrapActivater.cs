using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivater : MonoBehaviour
{
    Transform parent;
    private bool isActivated = false;
    private Vector3 defaultPosition;
    private Vector3 activPosition;
    private bool canActivate;

    [SerializeField] private float WaitTime;
    [SerializeField] private float activationDuration;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip trapSound;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        defaultPosition = new Vector3(parent.position.x, parent.position.y, parent.position.z);
        activPosition = new Vector3(parent.position.x, parent.position.y + 0.5f, parent.position.z);
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
        }
    }

    private IEnumerator GetTemporarilyActivated()
    {
        yield return new WaitForSeconds(WaitTime);

        Debug.Log("Trap is activ");
        isActivated = true;
        parent.position = activPosition;
        //audioSource.PlayOneShot(trapSound);

        yield return new WaitForSeconds(activationDuration);

        parent.position = defaultPosition;
        isActivated = false;
        Debug.Log("Trap is inactiv");
    }
}
