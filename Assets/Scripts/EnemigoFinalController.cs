using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFinalController : MonoBehaviour
{
    private float speed = 2f;
    private SpriteRenderer flip;
    private Animator anim;
    private float distancia;
    public Transform target;
    private Vector3 start, end;
    public bool isDeath;
    public GameObject bloodPrefab, keyPrefab;
    private AudioSource audioSourceEnemy;
    public AudioClip damage;
    private int vida = 3;
    private Rigidbody2D enemigoRb;
    private Color rojo =  new Color(231, 129, 129, 1);
    private Color blanco = new Color(255, 255, 255, 1);

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
        start = transform.position;
        end = target.position;
        isDeath = false;
        audioSourceEnemy = GetComponent<AudioSource>();
        enemigoRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
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
        if (collision.tag == "Arma")
        {
            if(vida > 0)
            {
                anim.SetTrigger("Herida");
                enemigoRb.AddForce((Vector2.left + Vector2.up) * 3, ForceMode2D.Impulse);
                vida--;
                flip.color = rojo;
            }else
            {
                gameObject.tag = "Ground";
                anim.SetTrigger("Die");
                audioSourceEnemy.PlayOneShot(damage);
                Instantiate(bloodPrefab, transform.position, Quaternion.identity);
                StartCoroutine("Muere");
            }
            
        }
    }

    IEnumerator Muere()
    {
        isDeath = true;
        yield return new WaitForSeconds(2f);
        Instantiate(keyPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce((Vector2.up + Vector2.left), ForceMode2D.Impulse);
        
        Destroy(gameObject);
    }
}
