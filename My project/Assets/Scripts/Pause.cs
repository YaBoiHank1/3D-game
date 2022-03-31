using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && canvas.enabled == false)
        {
            canvas.enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && canvas.enabled == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            canvas.enabled = false;
            Time.timeScale = 1;
        }

        if (Time.timeScale == 1)
        {
            canvas.enabled = false;
        }
    }
}
