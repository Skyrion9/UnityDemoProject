
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoEventListener : MonoBehaviour
{
    private demoEvent demoEvent;
    // Start is called before the first frame update
    void Start()
    {
        demoEvent = FindObjectOfType<demoEvent>();

        if(demoEvent  != null)
        {
            demoEvent.OnButtonClick += HandleButtonClick;
        }else
        {
            Debug.LogError("demoEvent bileseni bulunamadi.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleButtonClick()
    {
        Debug.Log("V tusuna basildi ve EventListener tarafindna islendi");
    }
}
