using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject fireBullet;
    public Transform bulletPoint;
    public float forceCount;
    public float Health = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBullet", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FireBullet()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject thisBullet = Instantiate(fireBullet, bulletPoint.position, Quaternion.identity);
            thisBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-400, 400), 500));
            Destroy(thisBullet, 10);
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerAttack")
        {
            Health--;
        }
     
    }
}
