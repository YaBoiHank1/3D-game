using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour
{
    public AudioSource audioSource;
    private int startingPitch = 1;
    private int runningPitch = 2;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startingPitch;
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = gameObject.GetComponent<Rigidbody>().velocity;
        if (velocity.x > 0 || velocity.x < 0 || velocity.y > 0 || velocity.y < 0 || velocity.z > 0 || velocity.z < 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
        else
        {
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            audioSource.pitch = runningPitch;
        }
        else
        {
            audioSource.pitch = startingPitch;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.Stop();
        }
    }
}
