using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_4 : MonoBehaviour
{
    public float MD = 0.01f;
    bool canRotation_1;
    bool canRotation_2;
    bool canRotation_4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject Spike_2 = GameObject.Find("平移_5b");
        Vector3 tempPosition = gameObject.transform.position;
        tempPosition.x -= MD;
        if (tempPosition.x <= 96)
        {
            MD = MD * -1;
            //Debug.Log("md");
        }

        if (tempPosition.x >= 101)
        {
            MD = MD * -1;
        }
        gameObject.transform.position = tempPosition;

        if (canRotation_1)
        {
            GameObject Spike_1 = GameObject.Find("旋转_1");
            Spike_1.transform.rotation = Quaternion.Lerp(Spike_1.transform.rotation, Quaternion.Euler(0, 0, 90), 1f * Time.deltaTime);
        }
        if (canRotation_2)
        {
            GameObject Spike_1 = GameObject.Find("旋转_2");
            Spike_1.transform.rotation = Quaternion.Lerp(Spike_1.transform.rotation, Quaternion.Euler(0, 0, -90), 1f * Time.deltaTime);
        }
        if (canRotation_4)
        {
            GameObject Spike_1 = GameObject.Find("旋转_4");
            Spike_1.transform.rotation = Quaternion.Lerp(Spike_1.transform.rotation, Quaternion.Euler(0, 0, 180), 1f * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "button_1" && collision.gameObject.tag == "Player")
        {
            canRotation_1 = true;
        }

        if (gameObject.name == "button_2" && collision.gameObject.tag == "Player")
        {
            canRotation_2 = true;
        }

        if (gameObject.name == "button_3" && collision.gameObject.tag == "Player")
        {
            GameObject Spike_1 = GameObject.Find("平移_3");
            Vector3 tempPosition = Spike_1.transform.position;
            tempPosition.y += 3;
            Spike_1.transform.position = tempPosition;
            //Destroy(button_3);
        }

        if (gameObject.name == "button_4" && collision.gameObject.tag == "Player")
        {
            canRotation_4 = true;
        }

        if (gameObject.name == "button_5" && collision.gameObject.tag == "Player")
        {
            GameObject Spike_1 = GameObject.Find("平移_5a");
            Vector3 tempPosition = Spike_1.transform.position;
            tempPosition.y += 10;
            Spike_1.transform.position = tempPosition;
            //Destroy(button_5);
        }


        }
    }
