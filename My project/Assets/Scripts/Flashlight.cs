using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light flashlight;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashlight.enabled)
        {
            flashlight.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.F) && !flashlight.enabled)
        {
            flashlight.enabled = true;
        }
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, 240))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            if (hit.collider != null)
            {
                
                if (flashlight.enabled == true)
                {
                    if (hit.collider.gameObject.GetComponent<EnemyNavigation>() != null)
                    {
                        hit.collider.gameObject.GetComponent<EnemyNavigation>().Chase();
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyNavigation>().lightHit = false;
                    }
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyNavigation>().lightHit = false;
                }
            }
        }
    }
}
