using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTracker : MonoBehaviour
{
    public int goal = 5;
    public Text objectiveText;
    private int collected = 0;

    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = collected.ToString() + "/" + goal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        objectiveText.text = collected.ToString() + "/" + goal.ToString();
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
