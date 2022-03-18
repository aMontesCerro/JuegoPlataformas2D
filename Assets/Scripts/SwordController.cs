using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private EnemyController enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = FindObjectOfType<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Enemy")
        {
            
            //Destroy(collision.gameObject);
        }
    }
}
