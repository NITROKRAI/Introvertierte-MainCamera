using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenerGround: MonoBehaviour
{    
    [SerializeField] private GameObject lockedDoor;
    
    private DoorUp doorUp;
    private Vector3 plate;

    // Start is called before the first frame update
    void Start()
    {
        doorUp = lockedDoor.GetComponent<DoorUp>();
        plate = transform.position;
    }
    private void OnTriggerStay(Collider col)
    {
        if ((col.gameObject.tag == "Player") || (col.gameObject.tag =="Box"))
        {
            Debug.Log("contact with smth.");
            transform.position = new Vector3(plate.x, plate.y - 0.2f, plate.z);

            doorUp.Unlock();
        }
    }
    
    private void OnTriggerExit(Collider col)
    {
        Debug.Log("No contact with smth.");
        transform.position = new Vector3(plate.x, plate.y, plate.z);

        doorUp.Lock();
    }
}
