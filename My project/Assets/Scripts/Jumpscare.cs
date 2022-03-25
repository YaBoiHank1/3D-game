using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<EnemyNavigation>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            gameObject.GetComponent<EnemyNavigation>().enabled = false;
        }
    }
}
