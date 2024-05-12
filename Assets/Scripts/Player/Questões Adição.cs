using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestõesAdição : MonoBehaviour
{
    public Canvas Q1,Q2,Q3,Q4,Q5;
    public bool npc1, npc2, npc3, npc4, npc5;

    void Start()
    {
        Q1.enabled = false;
        Q2.enabled = false;
        Q3.enabled = false;
        Q4.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (npc1 == true) {
                Q1.enabled = !Q1.enabled;
             }

            if (npc2 == true)
            {
                Q2.enabled = !Q2.enabled;
            }

            if (npc3 == true)
            {
                Q3.enabled = !Q3.enabled;
            }

            if (npc4 == true)
            {
                Q4.enabled = !Q4.enabled;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("NPC1"))
        {
            npc1 = true;

        }

        if (other.CompareTag("NPC2"))
        {
            npc2 = true;

        }

        if (other.CompareTag("NPC3"))
        {
            npc3 = true;

        }

        if (other.CompareTag("NPC4"))
        {
            npc4 = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("NPC1"))
        {
            npc1 = false;
            Q1.enabled = false;

        }

        if (other.CompareTag("NPC2"))
        {
            npc2 = false;
            Q2.enabled = false;

        }

        if (other.CompareTag("NPC3"))
        {
            npc3 = false;
            Q3.enabled = false;

        }

        if (other.CompareTag("NPC4"))
        {
            npc4 = false;
            Q4.enabled = false;

        }
    }
}
