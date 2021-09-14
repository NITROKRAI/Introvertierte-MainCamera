using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUp : MonoBehaviour
{
    Rigidbody rb;
    public float Speed = 0.09f;
    [SerializeField]private bool isUnlocked = false;    
    
    [SerializeField] private Transform[] movingPoints;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip doorSound;
    
    Vector3 defaultPosition;
    Vector3 endPosition;    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetChildPosition();       
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnlocked && rb.position != endPosition)
        {
            OpenDoor();
        }
        else if (!isUnlocked && rb.position != defaultPosition)
        {
            CloseDoor();
        }

    }

    //Start- und Zielstellung der Tür werden mit festen Punkten festgelegt
    private void GetChildPosition()
    {        
        movingPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            movingPoints[i] = transform.GetChild(i).transform;
        }
        defaultPosition = movingPoints[0].position;
        endPosition = movingPoints[1].position;
        //Debug.Log("default " + defaultPosition);
        //Debug.Log("Open " + endPosition);
    }

    public void OpenDoor()
    {
        rb.MovePosition(Vector3.Lerp(transform.position,endPosition,Speed));
        audioSource.PlayOneShot(doorSound);
    }

    public void CloseDoor()
    {
        rb.MovePosition(Vector3.Lerp(transform.position, defaultPosition, Speed));
        audioSource.PlayOneShot(doorSound);
    }

    public void Unlock()
    {
        isUnlocked = true;
        audioSource.PlayOneShot(doorSound);
    }
    public void Lock()
    {
        isUnlocked = false;
        audioSource.PlayOneShot(doorSound);
    }

    public bool IsUnlocked()
    {
        return isUnlocked;
    }
}
