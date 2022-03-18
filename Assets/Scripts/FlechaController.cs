using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaController : MonoBehaviour
{
    public Transform target;
    private float speed = 8f;
    private Transform playerPosition;
    private bool activar = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ( playerPosition.position.y  - transform.position.y < 3f)
        {
            activar = true;
            
        }
        if (activar)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Ground")
        {
            
            Destroy(gameObject);
        }else if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void Mover()
    {
        
    }
}
