using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_bullet : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (gameObject.tag == "enemyAttack" && collision.gameObject.tag == "defense")
        {
          
            gameObject.tag = "playerAttack";
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800);
            gameObject.transform.localScale = new Vector3(-1.4155f, 1.4155f, 1.4155f);
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerController2D.isDead = true;
        }
        if (collision.gameObject.tag == "playerAttack")
        {
            PlayerController2D.isDead = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
