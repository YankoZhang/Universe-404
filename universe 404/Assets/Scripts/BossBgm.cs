using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBgm : MonoBehaviour
{
    public AudioSource BGMAudio;
    public AudioClip DeadClip;
    public AudioClip StartClip;
    // Start is called before the first frame update
    void Start()
    {
        BGMAudio = GetComponent<AudioSource>();
        BGMAudio.clip = StartClip;
        BGMAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Boss.isDead)
        {
            if(BGMAudio.clip != DeadClip)
            {
                Debug.Log("111");
                BGMAudio.clip = DeadClip;
                BGMAudio.volume = 0.8f;
                BGMAudio.Play();
            }
           
        }
    }
}
