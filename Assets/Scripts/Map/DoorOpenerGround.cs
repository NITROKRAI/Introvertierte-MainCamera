using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenerGround: MonoBehaviour
{    
    [SerializeField] private GameObject lockedDoor;

    //private DoorUp doorUpFind;
    private DoorUp doorUp;

    // Start is called before the first frame update
    void Start()
    {
        //doorUpFind = FindObjectOfType<DoorUp>();
        doorUp = lockedDoor.GetComponent<DoorUp>();
    }
    private void OnCollisionEnter(Collision col)
    {       
        Debug.Log("contact with smth.");
        transform.position = new Vector3(transform.position.x,transform.position.y - 0.2f,transform.position.z);

        doorUp.Unlock();
        //doorUpFind.Unlock();
    }

    private void OnCollisionExit(Collision col)
    {
        Debug.Log("No contact with smth.");
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);

        doorUp.Lock();
        //doorUpFind.Lock();
    }
}
