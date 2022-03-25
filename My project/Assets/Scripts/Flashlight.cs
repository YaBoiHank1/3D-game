using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light flashlight;
    public AudioClip click;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashlight.enabled)
        {
            flashlight.enabled = false;
            audioSource.PlayOneShot(click);
        }
        else if (Input.GetKeyDown(KeyCode.F) && !flashlight.enabled)
        {
            flashlight.enabled = true;
            audioSource.PlayOneShot(click);
        }
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.red, 0.1f);
        if (Physics.Raycast(ray, out hit, 200))
        {
            
            if (hit.collider != null)
            {
                
                if (flashlight.enabled == true)
                {
                    if (hit.collider.gameObject.GetComponent<EnemyNavigation>() != null && hit.collider.gameObject.GetComponent<EnemyNavigation>().enabled == true)
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
