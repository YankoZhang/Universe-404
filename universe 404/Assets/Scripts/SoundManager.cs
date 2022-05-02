using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public GameObject soundOnIcon;
    public GameObject soundOffIcon;

    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (muted == false)
            {
                muted = true;
                AudioListener.pause = true;
            }

            else
            {
                muted = false;
                AudioListener.pause = false;
            }
        }
            
        Save();
        UpdateButtonIcon();
    }


    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.SetActive(true);
            soundOffIcon.SetActive(false);
        }
        else
        {
            soundOnIcon.SetActive(false);
            soundOffIcon.SetActive(true);
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 0;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
