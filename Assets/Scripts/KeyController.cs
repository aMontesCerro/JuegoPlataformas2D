using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private PlayerController playerScrpt;
    // Start is called before the first frame update
    void Start()
    {
        playerScrpt = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<ChestController>().hasKey = true;
            playerScrpt.KeySound();
            Destroy(gameObject);
        }
    }
}
