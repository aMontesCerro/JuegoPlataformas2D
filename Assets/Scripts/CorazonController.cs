using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorazonController : MonoBehaviour
{
    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerScript.Curar();
            playerScript.HearthSound();
            Destroy(gameObject);
        }
    }

}
