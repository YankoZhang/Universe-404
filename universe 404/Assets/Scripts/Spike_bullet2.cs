using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_bullet2 : MonoBehaviour
{
    float back = 3;
    float des = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      gameObject.transform.Translate(Vector2.right * back * Time.deltaTime);
        if(des == 0)
        {
            Destroy(gameObject);
            Launcher3.canLauncher = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController2D.isDead = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            des--;
            back = -3;
            gameObject.transform.localScale = new Vector3(-1.4115f,1.4115f,1.4115f);
        }
    
    }

}
