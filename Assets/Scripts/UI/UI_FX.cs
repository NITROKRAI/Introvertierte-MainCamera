using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;

    public void playHover()
    {
        audioSource.PlayOneShot(hoverSound);
    }

    public void playClick()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
