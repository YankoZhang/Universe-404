using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1InteractPressureKey : MonoBehaviour
{
    public GameObject door;
    public bool doorIsOpening;
    public Animator anim;

    void Update()
    {
        if(doorIsOpening)
        {
            door.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
        if(door.transform.position.y > 8f)
        {
            doorIsOpening = false;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            doorIsOpening = true;
            anim.SetBool("isPress", true);
        }
    }
}

