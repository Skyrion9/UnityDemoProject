using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class demoUnityEvent : MonoBehaviour
{
    public Light targetLight;
    // Start is called before the first frame update
    public UnityEvent onClickEvent;

    public Button button;
    void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnButtonClick()
    {
            onClickEvent.Invoke();

            if(targetLight != null)
        {
            targetLight.enabled = !targetLight.enabled;
        }
    }
}
