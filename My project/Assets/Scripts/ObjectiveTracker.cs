using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    public int goal = 5;
    private int collected = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectiveCollected()
    {
        collected++;
        if (collected >= goal)
        {
            Debug.Log("You Win");
        }
    }
}
