using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PausaController : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelInstrucciones, objetosInstrucciones;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
            panelPausa.SetActive(false);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
        panelInstrucciones.SetActive(false);
    }
    public void Instrucciones()
    {
        panelInstrucciones.SetActive(true);
        panelPausa.SetActive(false);
        objetosInstrucciones.SetActive(true);

    }
}
