using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToEnd : MonoBehaviour
{
    public string portalToScene;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {            
            SceneManager.LoadScene(portalToScene);
        }
    }
}
