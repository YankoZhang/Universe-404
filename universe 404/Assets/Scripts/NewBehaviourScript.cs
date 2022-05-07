using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{
    public VideoPlayer vPlayer;
    public GameObject can;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vPlayer.isPaused)
        {
            can.SetActive(true);
        }
    }
}
