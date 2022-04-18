using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1InteractPressureKey : MonoBehaviour
{
    public GameObject door;
    public bool doorIsOpening;

    void Update()
    {
        if(doorIsOpening == true)
        {
            door.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
        if(door.transform.position.y > 7f)
        {
            doorIsOpening = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            doorIsOpening = true;
        }
    }
}

