using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.5f;
    private float jumpForce = 8;
    private float movementX;
    public SpriteRenderer flip;
    private Rigidbody2D playerRb;
    private bool isGround = true;
    private AudioSource audioSourcePlayer;
    public AudioClip rubiSound, jumpSound, swordSound, hearthSound, escudoSound, pierdeEscudo, keySound;
    private Animator anim;
    public GameObject cameraPlayer;
    public GameObject bloodPrefab;
    public GameObject panelGameOver;
    public GameObject escudo;
    public GameObject panelPausa;
    public int vida;
    private int maxVida = 4;
    private VidasController vidas;
    private bool hasShield = false;
    private bool muerto = false;
    

    // Start is called before the first frame update
    void Start()
    {
        flip = GetComponentInChildren<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        audioSourcePlayer = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        vidas = FindObjectOfType<VidasController>();
        vida = maxVida;
        
    }

    // Update is called once per frame
    void Update()
    {

        vidas.CambioVida(vida);
        movementX = Input.GetAxis("Horizontal");
        if (movementX > 0)
        {
            anim.SetTrigger("Walk");
            flip.flipX = false;

        }

        if (movementX < 0)
        {
            anim.SetTrigger("Walk");
            flip.flipX = true;
        }
        this.transform.position += new Vector3(movementX, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            anim.SetTrigger("Jump");
            audioSourcePlayer.PlayOneShot(jumpSound);
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            anim.SetTrigger("Attack");
            audioSourcePlayer.PlayOneShot(swordSound);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            panelPausa.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "FallDownTrap")
        {
            isGround = true;
        }
        if( collision.gameObject.tag == "Enemy" )
        {
            if (hasShield)
            {
                hasShield = false;
                escudo.SetActive(false);
                audioSourcePlayer.PlayOneShot(pierdeEscudo);
            }
            else
            {
                playerRb.AddForce((Vector2.up + Vector2.left) * 2, ForceMode2D.Impulse);
                Instantiate(bloodPrefab, transform.position, Quaternion.identity);
                vida--;
            }
            
            if(vida == 0)
            {
                
                anim.SetTrigger("Die");
                cameraPlayer.transform.parent = null;
                panelGameOver.SetActive(true);
            }
            
            //Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Spike")
        {
            if (muerto)
            {

            }
            else
            {

                playerRb.AddForce((Vector2.up + Vector2.left) * 2, ForceMode2D.Impulse);
                Instantiate(bloodPrefab, transform.position, Quaternion.identity);
                anim.SetTrigger("Die");
                cameraPlayer.transform.parent = null;
                vida = 0;
                muerto = true;
                panelGameOver.SetActive(true);
                StartCoroutine("Muere");
               
            }
            
        }

       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "FallDownTrap")
        {
            isGround = false;
        }
    }

    public void Curar()
    {
        if (vida < maxVida)
        {
            vida++;
        }
    }

    public void Escudo()
    {
        hasShield = true;
        escudo.SetActive(true);
    }

    IEnumerator Muere()
    {

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void RubiSound()
    {
        audioSourcePlayer.PlayOneShot(rubiSound);
    }


    public void HearthSound()
    {
        audioSourcePlayer.PlayOneShot(hearthSound);
    }

    public void EscudoSound()
    {
        audioSourcePlayer.PlayOneShot(escudoSound);
    }

    public void KeySound()
    {
        audioSourcePlayer.PlayOneShot(keySound);
    }

}
