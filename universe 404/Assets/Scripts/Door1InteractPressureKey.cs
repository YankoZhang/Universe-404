using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1InteractPressureKey : MonoBehaviour
{
    public GameObject door;
    public bool doorIsOpening_1;
    public bool doorIsOpening_3;
    public Animator anim_1;
    public Animator anim_2;

    void Update()
    {
        if(doorIsOpening_1)
        {
            door.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
        if(door.transform.position.y > 8f)
        {
            doorIsOpening_1 = false;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && gameObject.name == "key_1")
        {
            doorIsOpening_1 = true;
            anim_1.SetBool("isPress", true);
            GameManager.instance.doorIsOpen_1 = true;
        }
        if (collision.gameObject.name == "Player" && gameObject.name == "key_2")
        {
            anim_2.Play("key_2_press");
            GameManager.instance.doorIsOpen_2 = true;
        }
        if (collision.gameObject.name == "Player" && gameObject.name == "key_3")
        {
            Destroy(GameObject.Find("key_3"));
            Destroy(GameObject.Find("Door_2"));
            GameManager.instance.doorIsOpen_3 = true;
        }
    }
}

