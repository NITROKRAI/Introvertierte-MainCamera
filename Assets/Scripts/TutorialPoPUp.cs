using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPoPUp : MonoBehaviour
{
    public GameObject PopUpWindow;
    Text WindowText;
    public float Width;
    public float Height;
    public float FadeInAndOutTime;
    public string PopUpText;
    
    // Start is called before the first frame update
    void Start()
    {
        WindowText = PopUpWindow.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            WindowText.text = PopUpText;
            LeanTween.scale(PopUpWindow.gameObject, new Vector3(Width, Height, 1), FadeInAndOutTime);
            Invoke("DeactivateInfo", 5f);
        }
    }
    private void DeactivateInfo()
    {
        LeanTween.scale(PopUpWindow.gameObject, new Vector3(0, 0, 0), FadeInAndOutTime);
    }
}
