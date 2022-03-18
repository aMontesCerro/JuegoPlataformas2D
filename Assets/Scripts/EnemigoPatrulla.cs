using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPatrulla : MonoBehaviour
{
    private float speed = 2f;
    private SpriteRenderer flip;
    private Animator anim;
    private float distancia;
    public Transform target;
    private Vector3 start, end;
    public bool isDeath;
    public GameObject bloodPrefab;
    private AudioSource audioSourceEnemy;
    public AudioClip damage;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
        start = transform.position;
        end = target.position;
        isDeath = false;
        audioSourceEnemy = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDeath)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position == target.position)
            {
                if (target.position == end)
                {
                    target.position = start;
                    flip.flipX = true;
                }
                else
                {
                    target.position = end;
                    flip.flipX = false;
                }
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Arma")
        {
            gameObject.tag = "Ground";
            anim.SetTrigger("Die");
            audioSourceEnemy.PlayOneShot(damage);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            StartCoroutine("Muere");
        }
    }

    IEnumerator Muere()
    {
        isDeath = true;
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
