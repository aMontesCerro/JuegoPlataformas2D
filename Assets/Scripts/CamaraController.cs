using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    private Transform playerPosition;
    private Vector3 targetPos;
    private PlayerController playerScript;
    private Vector3 posicion = new Vector3(0, 2, -1);
    public float avance;
    public float smothing;
    private float jugadorX, jugadorY;
    private float minX = -7f;
    private float maxX = 115.5f;
    private float posZ = -1f;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").transform;
        playerScript = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        jugadorX = playerPosition.position.x;
        jugadorY = playerPosition.position.y;
        targetPos = new Vector3(playerPosition.position.x, playerPosition.position.y + 2, posZ);

        if(jugadorX > minX && jugadorX < maxX)
        {
            
            if (playerScript.flip.flipX == false)
            {
                targetPos = new Vector3(targetPos.x + avance, targetPos.y, posZ);
            }
            if (playerScript.flip.flipX == true)
            {
                targetPos = new Vector3(targetPos.x - avance, targetPos.y, posZ);
            }

            
        }
        if (jugadorX < minX)
        {
            targetPos = new Vector3(minX, targetPos.y, posZ);
        }
        if(jugadorX > maxX)
        {
            targetPos = new Vector3(maxX, targetPos.y, posZ);
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, smothing * Time.deltaTime);
    }
}
