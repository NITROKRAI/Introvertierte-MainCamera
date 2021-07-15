using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playerLives;
    public TMPro.TextMeshProUGUI playerLives2;

    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLives.text = player.lives.ToString();
        playerLives2.text = player.lives.ToString();
    }
}
