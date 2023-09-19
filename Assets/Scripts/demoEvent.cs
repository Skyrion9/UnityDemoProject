using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoEvent : MonoBehaviour
{
    public event Action OnButtonClick;
    // Start is called before the first frame update
    void Start()
    {
        OnButtonClick += HandleButtonClick;
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.V))
        {
            OnButtonClick?.Invoke();
        }
    }

    private void HandleButtonClick()
    {
        Debug.Log("V tusuna basildi");
    }
}
