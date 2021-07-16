using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutomatic : MonoBehaviour
{
    [SerializeField] private GameObject lockedDoor;
    private DoorUp doorUp;
    private bool inZone = true;
    //RaycastHit[] hits;
    //LayerMask playerMask;
    // Start is called before the first frame update
    void Start()
    {
        doorUp = lockedDoor.GetComponent<DoorUp>();
        //playerMask = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == ("Enemy"))
        {
            inZone = true;
            Debug.LogWarning("Enemy in Zone");
            doorUp.Lock();
        }
        else if (!(col.gameObject.tag == ("Enemy")))
        {
            inZone = false;
            Debug.LogError("No Enemy in Zone");
            doorUp.Unlock();            
        }        
    }

    public bool InZone()
    {
        return inZone;
    }


    /*
    private void ScanEnemy()
    {        
        hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity,playerMask);
    }

    private void Output()
    {
        foreach (var hit in hits)
        {
            Debug.Log(hit);
        }
    }
    */
}
