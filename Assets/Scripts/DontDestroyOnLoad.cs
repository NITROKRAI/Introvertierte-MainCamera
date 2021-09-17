using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static GameObject Instance;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this.gameObject;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    
    void Update()
    {
        
    }
}
