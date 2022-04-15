using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Animator anim_key;
    public bool isPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPress)
        {
            Transform door = gameObject.transform.Find("Door_1");
            door.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            anim_key.SetBool("isPress",true);
            isPress = true;
        }
    }
}
