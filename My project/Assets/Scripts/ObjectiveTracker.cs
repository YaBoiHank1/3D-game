using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTracker : MonoBehaviour
{
    public int goal1 = 5;
    public int goal2 = 2;
    public bool goal1Done;
    public bool goal2Done;
    public Text objectiveText;
    private int collected = 0;

    // Start is called before the first frame update
    void Start()
    {
        goal1Done = false;
        goal2Done = false;
        objectiveText.text = collected.ToString() + "/" + goal1.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!goal1Done)
        {
            objectiveText.text = "Find Gas Cans " + collected.ToString() + "/" + goal1.ToString();
        }
        else if (goal1Done)
        {
            objectiveText.text = "Find a Spare Tire " + collected.ToString() + "/" + goal2.ToString();
        }
    }

    public void ObjectiveCollected()
    {
        collected++;
        if (collected >= goal1 && !goal1Done)
        {
            collected = 0;
            goal1Done = true;
        }
        if (collected >= goal2 && goal1Done)
        {
            goal2Done = true;
        }
    }
}
