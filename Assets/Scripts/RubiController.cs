using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubiController : MonoBehaviour
{
    private static int points = 0;
    public Text pointsText;
    public Text puntosFinal, textoRecord;
    private PlayerController playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerController>();
        textoRecord.text = PlayerPrefs.GetInt("PuntosRecord", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if(collision.gameObject.tag   == "Player")
        {
            playerScript.RubiSound();
            points += 5;
            pointsText.text = "Puntos: " + points.ToString();
            puntosFinal.text = "Puntos: " + points.ToString();
            if(points > PlayerPrefs.GetInt("PuntosRecord", 0))
            {
                PlayerPrefs.SetInt("PuntosRecord", points);
                textoRecord.text ="Record: " + points.ToString();
            }
            Destroy(gameObject);
        }
    }

    
}
