using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoController : MonoBehaviour
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
        if(collision.tag == "Player")
        {
            playerScript.Escudo();
            playerScript.EscudoSound();
            Destroy(gameObject);
        }
    }
}
