using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutomatic : MonoBehaviour
{
    private DoorUp doorUp;
    [SerializeField] private GameObject lockedDoor;
    [SerializeField] private List<GameObject> enemys = new List<GameObject>();    

    void Start()
    {
        doorUp = lockedDoor.GetComponent<DoorUp>();        
    }

    // Update is called once per frame
    void Update()
    {
        ListClearer();
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

    private void ListClearer()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            if(enemys[i] == null)
            {
                enemys.RemoveAt(i);
            }
        }
    }
}
