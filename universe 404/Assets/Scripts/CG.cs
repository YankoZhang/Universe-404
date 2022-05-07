using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CG : MonoBehaviour
{
    public  VideoPlayer vPlayer;
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
        if(collision.gameObject.name == "Player")
        {
            vPlayer.Play();
            GameObject player = GameObject.Find("Player");
            GameObject pos = transform.Find("pos").gameObject;
            player.transform.position = pos.transform.position;
        }
    }
}
