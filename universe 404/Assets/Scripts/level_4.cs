using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_4 : MonoBehaviour
{
    float _time = 3f;
    public float MD = 0.01f;
    bool canRotation_1;
    bool canRotation_2;
    bool canMove_3;
    bool canRotation_4;
    bool canMove_5a;
    bool canRotation_6;
    bool canMove_7;
    bool canMove_8;
    bool canMove_9;
    bool canMove_hit;
    bool canRotation_e1;
    float e1 = 0;
    bool canRotation_e2;
    float e2 = 0;
    bool canRotation_e3;
    float e3 = 0;
    bool canRotation_e4;
    float e4 = 0;
    bool canRotation_e5;
    bool canRotation_e6;
    bool canBreak_1;
    bool canBreak_2;
    bool canBreak_3;
    bool canBreak_4;
    public AudioSource hitAudio;
    // Start is called before the first frame update
    void Start()
    {
        hitAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(gameObject.name == "平移_5b")
        {
            Vector3 tempPosition = gameObject.transform.position;
            tempPosition.x -= MD;
            if (tempPosition.x <= 96)
            {
                MD = MD * -1;
            }

            if (tempPosition.x >= 101)
            {
                MD = MD * -1;
            }
            gameObject.transform.position = tempPosition;
        }
        if (canRotation_1)
        {
            if(hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            
            GameObject Spike = GameObject.Find("旋转_1");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, 90), 1f * Time.deltaTime);
        }
        if (canRotation_2)
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("旋转_2");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, -90), 1f * Time.deltaTime);
        }
        if (canMove_3)
        {
            GameObject Spike = GameObject.Find("平移_3");
            Spike.transform.Translate(Vector3.up * Time.deltaTime);
            if(Spike.transform.position.y >= -95)
            {
                canMove_3 = false;
            }
        }
        if (canRotation_4)
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("旋转_4");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, 180), 1f * Time.deltaTime);
        }
        if (canRotation_6 )
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("旋转_6");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, 90), 1f * Time.deltaTime);
        }
        if (canMove_5a)
        {
            GameObject Spike = GameObject.Find("平移_5a");
            Spike.transform.Translate(Vector3.up * Time.deltaTime);
            if (Spike.transform.position.y >= 10)
            {
                canMove_5a = false;
            }
        }
        if (canMove_7)
        {
            GameObject Spike = GameObject.Find("平移_7");
            Spike.transform.Translate(Vector3.up * Time.deltaTime);
            if (Spike.transform.position.y >= -83)
            {
                canMove_7 = false;
            }
        }
        if (canMove_8)
        {
            GameObject Spike = GameObject.Find("平移_8");
            Spike.transform.Translate(Vector3.down * Time.deltaTime);
            if (Spike.transform.position.y <= -90)
            {
                canMove_8 = false;
            }
        }
        if (canMove_9)
        {
            GameObject Spike = GameObject.Find("平移_9");
            Spike.transform.Translate(Vector3.up * Time.deltaTime);
            if (Spike.transform.position.y >= -74.5)
            {
                canMove_9 = false;
            }
        }
        if (canMove_hit)
        {
          
             _time -= Time.deltaTime;
            if(_time <= 0)
            {
                GameObject Spike = GameObject.Find("触发尖刺");
                Spike.transform.Translate(Vector3.left * Time.deltaTime);
                if (Spike.transform.position.x <= 120.8)
                {
                    canMove_hit = false;
                }
            }
           
        }
        if (canBreak_1)
        {
            GameObject Spike = GameObject.Find("break_1");
            Destroy(Spike);
        }
        if (canBreak_2)
        {
            GameObject Spike = GameObject.Find("break_2");
            Destroy(Spike);
        }
        if (canBreak_3)
        {
            GameObject Spike = GameObject.Find("break_3");
            Destroy(Spike);
        }
        if (canBreak_4)
        {
            GameObject Spike = GameObject.Find("break_4");
            Destroy(Spike);
        }


        if (canRotation_e1)
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("俄罗斯方块_1");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, 90*e1), 1f * Time.deltaTime);
        }
        if (canRotation_e2 )
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("俄罗斯方块_2");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, 90 * e2), 1f * Time.deltaTime);
        }
        if (canRotation_e3 )
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("俄罗斯方块_3");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, 90 * e3), 1f * Time.deltaTime);
        }
        if (canRotation_e4)
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("俄罗斯方块_4");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, 90 * e4), 1f * Time.deltaTime);
        }
        if (canRotation_e5)
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("俄罗斯方块_5");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, -90), 1f * Time.deltaTime);
        }
        if (canRotation_e6)
        {
            if (hitAudio.isPlaying == false)
            {
                hitAudio.Play();
            }
            GameObject Spike = GameObject.Find("俄罗斯方块_6");
            Spike.transform.rotation = Quaternion.Lerp(Spike.transform.rotation, Quaternion.Euler(0, 0, 90), 1f * Time.deltaTime);
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
            canMove_3 = true;
        }

        if (gameObject.name == "button_4" && collision.gameObject.tag == "Player")
        {
            canRotation_4 = true;
        }

        if (gameObject.name == "button_5" && collision.gameObject.tag == "Player")
        {
            canMove_5a = true;
        }
        if (gameObject.name == "button_hit" && collision.gameObject.tag == "Player")
        {
            hitAudio.Play();
            canMove_hit = true;
        }
        if (gameObject.name == "button_e1" && collision.gameObject.tag == "Player")
        {
            canRotation_e1 = true;
            e1++;
        }
        if (gameObject.name == "button_e2" && collision.gameObject.tag == "Player")
        {
            canRotation_e2 = true;
            e2++;
        }
        if (gameObject.name == "button_e3" && collision.gameObject.tag == "Player")
        {
            canRotation_e3 = true;
            e3++;
        }
        if (gameObject.name == "button_e4" && collision.gameObject.tag == "Player")
        {
            canRotation_e4 = true;
            e4++;
        }
        if (gameObject.name == "button_e5" && collision.gameObject.tag == "Player")
        {
            canRotation_e5 = true;
        }
        if (gameObject.name == "button_e6" && collision.gameObject.tag == "Player")
        {
            canRotation_e6 = true;
        }

        if (gameObject.name == "button_6" && collision.gameObject.tag == "Player")
        {
            canRotation_6 = true;
        }
        if (gameObject.name == "平移_7" && collision.gameObject.tag == "Player")
        {
            canMove_7 = true;
        }
        if (gameObject.name == "button_8" && collision.gameObject.tag == "Player")
        {
            canMove_8 = true;
        }
        if (gameObject.name == "平移_9" && collision.gameObject.tag == "Player")
        {
            canMove_9 = true;
        }
        if (gameObject.name == "button_9" && collision.gameObject.tag == "Player")
        {
            canBreak_1 = true;
        }
        if (gameObject.name == "button_10" && collision.gameObject.tag == "Player")
        {
            canBreak_2 = true;
        }
        if (gameObject.name == "button_11" && collision.gameObject.tag == "Player")
        {
            canBreak_3 = true;
        }
        if (gameObject.name == "button_12" && collision.gameObject.tag == "Player")
        {
            canBreak_4 = true;
        }
    }

 
}
