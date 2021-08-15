using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutomatic : MonoBehaviour
{
    [SerializeField] private GameObject lockedDoor;
    [SerializeField] private List<GameObject> enemys = new List<GameObject>();
    private DoorUp doorUp;


    void Start()
    {
        doorUp = lockedDoor.GetComponent<DoorUp>();
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCheck();
    }

    private void EnemyCheck()
    {
        if(enemys.Count == 0)
        {
            doorUp.Unlock();
        }
        else
        {
            doorUp.Lock();
        }
    }
}
