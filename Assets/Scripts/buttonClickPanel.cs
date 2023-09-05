using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonClickPanel : MonoBehaviour
{
    public GameObject Panel;

    public AudioSource audioSource;

    private bool isPaused = true;
    private bool isSoundOn = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void taskOnClick()
    {
        if(isPaused) //if paused, pause time and enable panel. Else resume and disable panel.
        {
            Time.timeScale = 1;
            Panel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
        }
    }

    public void SoundButton()
    {
        if (isSoundOn)  //if sound button pressed, turn off volume when function called.
        {
            audioSource.volume = 0;
        }
        else {
            audioSource.volume = 1;
        }
    }
}
