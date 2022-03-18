using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuenteTrampa : MonoBehaviour
{
    private AudioSource audioPuente;
    public AudioClip audioCaida;
    // Start is called before the first frame update
    void Start()
    {
        audioPuente = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            StartCoroutine("Caida");
        }
        if ( collision.gameObject.tag == "Spike")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Caida()
    {
        audioPuente.PlayOneShot(audioCaida);
        yield return new WaitForSeconds(1f);
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
