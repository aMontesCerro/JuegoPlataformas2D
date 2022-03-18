using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator animatorChest;
    public bool hasKey = false;
    public GameObject panelWin;
    public GameObject resplandorPrefab;
    public GameObject panelDialogo;
    // Start is called before the first frame update
    void Start()
    {
        animatorChest = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (hasKey)
            {
                animatorChest.SetBool("isOpen", true);
                Instantiate(resplandorPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                panelWin.SetActive(true);
            }
            else
            {
                panelDialogo.SetActive(true);
            }
            
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        panelDialogo.SetActive(false);
    }
}
