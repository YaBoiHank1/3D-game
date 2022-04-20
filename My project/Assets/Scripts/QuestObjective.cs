using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjective : MonoBehaviour
{
    public Text pickupText;
    public Text depositText;
    public Text notEnough;
    private bool canPickUp;
    private bool canDeposit;
    public int on;

    // Start is called before the first frame update
    void Start()
    {
        pickupText.enabled = false;
        depositText.enabled = false;
        notEnough.enabled = false;
        canPickUp = false;
        canDeposit = false;
        on = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (on == 1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (on == 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        Deposit();
        PickUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag != "Sedan" && other.gameObject.tag == "Player")
        {
            pickupText.enabled = true;
            canPickUp = true;
        }
        if (gameObject.tag == "Sedan" && other.gameObject.tag == "Player")
        {
            depositText.enabled = true;
            if (canDeposit == true)
            {
                notEnough.enabled = false;
                //FindObjectOfType<ObjectiveTracker>().Deposit();
            }
            else if (canDeposit == false)
            {
                notEnough.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(gameObject.tag != "Sedan" &&  other.gameObject.tag == "Player")
        {
            pickupText.enabled = false;
            canPickUp = false;
        }
        if (gameObject.tag == "Sedan" && other.gameObject.tag == "Player")
        {
            depositText.enabled = false;
            if (notEnough.enabled == true)
            {
                notEnough.enabled = false;
            }
        }
    }

    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canPickUp == true)
            {
                pickupText.enabled = false;
                notEnough.enabled = false;
                FindObjectOfType<ObjectiveTracker>().ObjectiveCollected();
                canPickUp = false;
                on = 0;
            }
        }
        
    }

    private void Deposit()
    {
        if (canDeposit == true && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<ObjectiveTracker>().Deposit();
        }
        if (FindObjectOfType<ObjectiveTracker>().goalDone == true)
        {
            canDeposit = true;
        }
        notEnough.text = "Not enough gas. You need " + (FindObjectOfType<ObjectiveTracker>().goal - FindObjectOfType<ObjectiveTracker>().collected) + " more.";
    }
}
