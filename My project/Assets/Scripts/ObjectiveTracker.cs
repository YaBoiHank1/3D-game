using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveTracker : MonoBehaviour
{
    public int goal = 5;
    public bool goalDone;
    public Text objectiveText;
    public int collected = 0;

    // Start is called before the first frame update
    void Start()
    {
        goalDone = false;
        objectiveText.text = collected.ToString() + "/" + goal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!goalDone)
        {
            objectiveText.text = "Find Gas Cans " + collected.ToString() + "/" + goal.ToString();
        }
        else if (goalDone)
        {
            objectiveText.text = "Get Back to your car";
        }
    }

    public void ObjectiveCollected()
    {
        collected++;
        if (collected >= goal && !goalDone)
        {
            collected = 0;
            goalDone = true;
        }
    }

    public void Deposit()
    {
        SceneManager.LoadScene(3);
    }
}
