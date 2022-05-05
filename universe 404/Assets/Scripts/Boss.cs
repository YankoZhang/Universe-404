using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject fireBullet;
    public Transform bulletPoint;
    public float forceCount;
    public int Health = 10;
    public Animator bossAnim;
    public float attackType;
    // Start is called before the first frame update
    void Start()
    {
        bossAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            bossAnim.Play("ËÀÍö");
        }
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
            bossAnim.Play("ÊÜ»÷");
            Health--;
            Destroy(collision.gameObject);
            Time.timeScale = 0.1f;
            Invoke("TimeStopEnd", 0.05f);
        }
       
     
    }

    public void switchAttackType()
    {
        attackType = Random.Range(0,10);
        Debug.Log(attackType);
        if(attackType == 0 | attackType ==1 | attackType == 2)
        {
            bossAnim.Play("»ðÇò¹¥»÷");
        }
        if (attackType == 3 | attackType == 4 | attackType == 5)
        {
            bossAnim.Play("Ðý×ª");
        }
        if (attackType == 6| attackType == 7)
        {
            bossAnim.Play("´¥ÊÖ");
        }
        if (attackType == 8 | attackType == 9)
        {
            bossAnim.Play("´¥ÊÖ2");
        }

    }

    public void TimeStopEnd()
    {
        Time.timeScale = 1;
    }

    public void DeadShake()
    {
        CameraShake.Instance.canShake(0.01f, 5f);
    }
    public void StartShake()
    {
        CameraShake.Instance.canHorShake(0.03f, 2f);
    }
}
