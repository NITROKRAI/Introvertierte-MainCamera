using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUp : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.09f;
    private bool isUnlocked = false;
    [SerializeField] private Transform[] movingPoints;
    Vector3 defaultPosition;
    Vector3 endPosition;
    Vector3 localScale;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
        
        //Start- und Zielstellung der Tür werden ohne feste Punkte festgelegt
        /*
        defaultPosition = transform.localPosition;
        Debug.Log(transform.localScale);
        localScale = transform.localScale;
        endPosition = transform.localPosition + new Vector3(0, localScale.y / 2, 0);
        */
       
        //Start- und Zielstellung der Tür werden mit festen Punkten festgelegt
        movingPoints = new Transform[transform.childCount];               
        for (int i = 0; i < transform.childCount; i++)
        {
            movingPoints[i] = transform.GetChild(i).transform;
        }
        defaultPosition = movingPoints[0].position;
        endPosition = movingPoints[1].position;
        Debug.Log("default " + defaultPosition);
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();       
        CloseDoor();
    }

    public void OpenDoor()
    {
        if (isUnlocked)
        {
            //rb.velocity = (new Vector3(rb.position.x, speed, rb.position.z));
            rb.MovePosition(Vector3.Lerp(transform.position,endPosition,speed)); 
        }
    }

    public void CloseDoor()
    {
        if (!isUnlocked)
        {
            //rb.velocity = (new Vector3(rb.position.x, -speed, rb.position.z));
            rb.MovePosition(Vector3.Lerp(transform.position, defaultPosition, speed));
        }
    }

    public void Unlock()
    {
        isUnlocked = true;
    }
    public void Lock()
    {
        isUnlocked = false;
    }

    public bool IsUnlocked()
    {
        return isUnlocked;
    }
}
