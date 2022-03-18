using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform playerPosition;
    private float speed = 2f;
    private SpriteRenderer flip;
    private Animator anim;
    private float distancia;
    private AudioSource audioSourceEnemy;
    public AudioClip damage;
    public GameObject bloodPrefab;
    private bool isDeath;
    // Start is called before the first frame update
    void Start()
    {
        isDeath = false;
        playerPosition = GameObject.Find("Player").transform;
        anim = GetComponentInChildren<Animator>();
        flip = GetComponentInChildren<SpriteRenderer>();
        audioSourceEnemy = GetComponentInChildren<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {
        distancia = transform.position.x - playerPosition.position.x;
        
        if (isDeath == false)
        {
            if (distancia < 5f && distancia > -5f)
            {

                anim.SetTrigger("Attack");
                transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
            }
            else if (distancia < 12f && distancia > -12f)
            {
                anim.SetTrigger("Walk");
                transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
            }
            if (distancia < 0)
            {
                flip.flipX = false;

            }
            if (distancia > 0)
            {
                flip.flipX = true;

            }
        }
       
         
    }

    

    public void OnTriggerEnter2D (Collider2D collision)
    {
            if (collision.gameObject.tag == "Arma")
            {
            
            this.gameObject.tag = "Ground";
            anim.SetTrigger("Die");
            this.isDeath = true;
            Debug.Log(isDeath);
            //audioSourceEnemy.PlayOneShot(damage);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            StartCoroutine("Muere");
        }
    }


    IEnumerator Muere()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }
