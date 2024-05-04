using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestõesAdição : MonoBehaviour
{
    public Canvas Q1,Q2;
    public bool npc1, npc2;

    void Start()
    {
        Q1.enabled = false;
        Q2.enabled = false;
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
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("NPC1"))
        {
            npc1 = false;

        }

        if (other.CompareTag("NPC2"))
        {
            npc2 = false;

        }
    }
}
