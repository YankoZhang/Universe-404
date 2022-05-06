using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Transform attackTransform;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        GameObject attackPos = transform.Find("pos").gameObject;
        attackTransform = attackPos.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float canAttack = Random.Range(0, 1000);
        if(canAttack == 0)
        {
            GameObject thisBullet = Instantiate(bullet, attackTransform.position, Quaternion.Euler(0, 0, -90));
        }
        
    }
}
