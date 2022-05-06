using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher2 : MonoBehaviour
{
    public Transform attackTransform;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        GameObject attackPos = transform.Find("pos").gameObject;
        attackTransform = attackPos.transform;
        InvokeRepeating("ButtleLauncher", 0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    public void ButtleLauncher()
    {
        GameObject thisBullet = Instantiate(bullet, attackTransform.position, Quaternion.Euler(0, 0, 0));
    }
}
