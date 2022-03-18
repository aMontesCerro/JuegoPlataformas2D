using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform target;
    private float speed = 2f;
    private Vector3 start, end;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        end = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if(transform.position == target.position)
        {
            if(target.position == end)
            {
                target.position = start;
            }
            else
            {
                target.position = end;
            }
        }
    }

    private void OnCollisionEnter2D ( Collision2D collision)
    {
        collision.transform.parent = transform;
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
