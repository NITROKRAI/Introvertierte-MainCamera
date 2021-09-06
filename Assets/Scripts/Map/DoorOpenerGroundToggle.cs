using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenerGroundToggle : MonoBehaviour
{
    [SerializeField] private GameObject lockedDoor;

    private DoorUp doorUp;
    private Vector3 plate;
    public bool IsToggled;

    // Start is called before the first frame update
    void Start()
    {
        IsToggled = false;
        doorUp = lockedDoor.GetComponent<DoorUp>();
        plate = transform.position;
    }
    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "Box"))
        { 
            doorUp.Unlock();
        }
    }

    //private void OnTriggerExit(Collider col)
    //{
    //    transform.position = new Vector3(plate.x, plate.y, plate.z);

    //    doorUp.Lock();
    //}
}
