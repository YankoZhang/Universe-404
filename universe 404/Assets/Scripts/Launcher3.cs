using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher3 : MonoBehaviour
{
    public Transform attackTransform;
    public GameObject bullet;
    public static bool canLauncher = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject attackPos = transform.Find("pos").gameObject;
        attackTransform = attackPos.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (canLauncher)
        {
            ButtleLauncher();
            canLauncher = false;
        }
            
    }

    public void ButtleLauncher()
    {
        GameObject thisBullet = Instantiate(bullet, attackTransform.position, Quaternion.Euler(0, 0, -180));
    }
}
