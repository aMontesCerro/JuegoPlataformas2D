using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panelInstrucciones;
    public GameObject panelIntro, objetosIntro, objetosInstrucciones;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Iniciar()
    {
        SceneManager.LoadScene("Game");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Instrucciones()
    {
        panelInstrucciones.SetActive(true);
        panelIntro.SetActive(false);
        objetosIntro.SetActive(false);
        objetosInstrucciones.SetActive(true);

    }

    public void Volver()
    {
        panelInstrucciones.SetActive(false);
        objetosInstrucciones.SetActive(false);

        panelIntro.SetActive(true);
        objetosIntro.SetActive(true);

    }
}
