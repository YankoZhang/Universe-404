using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public Transform attackTransform;
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
        GameObject attackPos = GameObject.Find("AttackPos");
        attackTransform = attackPos.transform;
        if (gameObject.tag == "enemyAttack" && collision.gameObject.tag == "defense")
        {
            gameObject.tag = "playerAttack";
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(attackPos.transform.position.x - transform.position.x, attackPos.transform.position.y - transform.position.y) * 300);
            CameraShake.Instance.canShake(0.02f, 0.25f);
            Debug.Log("±»»÷ÖÐ");
            Debug.Log((attackPos.transform.position.x - transform.position.x, attackPos.transform.position.y - transform.position.y));
        }

        
    }
}
