using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject SelectedGameObject;

    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && selected == false)
        {
            eventSystem.SetSelectedGameObject(SelectedGameObject);
            selected = true;
        }
    }

    private void Disable()
    {
        selected = false;
    }
}
