using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestõesAdição : MonoBehaviour
{
    public Canvas Q1,Q2,Q3,Q4,Q5;
    public bool npc1, npc2, npc3, npc4, npc5;
    public Canvas Q1_sub, Q2_sub, Q3_sub, Q4_sub, Q5_sub;
    public bool npc1_sub, npc2_sub, npc3_sub, npc4_sub, npc5_sub;
    public Canvas Q1_mult, Q2_mult, Q3_mult, Q4_mult, Q5_mult;
    public bool npc1_mult, npc2_mult, npc3_mult, npc4_mult, npc5_mult;

    void Start()
    {
        Q1.enabled = false;
        Q2.enabled = false;
        Q3.enabled = false;
        Q4.enabled = false;
        Q5.enabled = false;

        Q1_sub.enabled = false;
        Q2_sub.enabled = false;
        Q3_sub.enabled = false;
        Q4_sub.enabled = false;
        Q5_sub.enabled = false;

        Q1_mult.enabled = false;
        Q2_mult.enabled = false;
        Q3_mult.enabled = false;
        Q4_mult.enabled = false;
        Q5_mult.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //questões adição
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

            if (npc5 == true)
            {
                Q5.enabled = !Q5.enabled;
            }

            //questões subtração
            if (npc1_sub == true)
            {
                Q1_sub.enabled = !Q1_sub.enabled;
            }

            if (npc2_sub == true)
            {
                Q2_sub.enabled = !Q2_sub.enabled;
            }

            if (npc3_sub == true)
            {
                Q3_sub.enabled = !Q3_sub.enabled;
            }

            if (npc4_sub == true)
            {
                Q4_sub.enabled = !Q4_sub.enabled;
            }

            if (npc5_sub == true)
            {
                Q5_sub.enabled = !Q5_sub.enabled;
            }

            //questões multiplicação
            if (npc1_mult == true)
            {
                Q1_mult.enabled = !Q1_mult.enabled;
            }

            if (npc2_mult == true)
            {
                Q2_mult.enabled = !Q2_mult.enabled;
            }

            if (npc3_mult == true)
            {
                Q3_mult.enabled = !Q3_mult.enabled;
            }

            if (npc4_mult == true)
            {
                Q4_mult.enabled = !Q4_mult.enabled;
            }

            if (npc5_mult == true)
            {
                Q5_mult.enabled = !Q5_mult.enabled;
            }



        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("NPC1")) { npc1 = true; }
        if (other.CompareTag("NPC2")) { npc2 = true; }
        if (other.CompareTag("NPC3")) { npc3 = true; }
        if (other.CompareTag("NPC4")) { npc4 = true; }
        if (other.CompareTag("NPC5")) { npc5 = true; }

        if (other.CompareTag("NPC1_Sub")) { npc1_sub = true; }
        if (other.CompareTag("NPC2_Sub")) { npc2_sub = true; }
        if (other.CompareTag("NPC3_Sub")) { npc3_sub = true; }
        if (other.CompareTag("NPC4_Sub")) { npc4_sub = true; }
        if (other.CompareTag("NPC5_Sub")) { npc5_sub = true; }

        if (other.CompareTag("NPC1_Mult")) { npc1_mult = true; }
        if (other.CompareTag("NPC2_Mult")) { npc2_mult = true; }
        if (other.CompareTag("NPC3_Mult")) { npc3_mult = true; }
        if (other.CompareTag("NPC4_Mult")) { npc4_mult = true; }
        if (other.CompareTag("NPC5_Mult")) { npc5_mult = true; }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("NPC1")) { npc1 = false; Q1.enabled = false; }
        if (other.CompareTag("NPC2")) { npc2 = false; Q2.enabled = false; }
        if (other.CompareTag("NPC3")) { npc3 = false; Q3.enabled = false; }
        if (other.CompareTag("NPC4")) { npc4 = false; Q4.enabled = false; }
        if (other.CompareTag("NPC5")) { npc5 = false; Q5.enabled = false; }

        if (other.CompareTag("NPC1_Sub")) { npc1_sub = false; Q1_sub.enabled = false; }
        if (other.CompareTag("NPC2_Sub")) { npc2_sub = false; Q2_sub.enabled = false; }
        if (other.CompareTag("NPC3_Sub")) { npc3_sub = false; Q3_sub.enabled = false; }
        if (other.CompareTag("NPC4_Sub")) { npc4_sub = false; Q4_sub.enabled = false; }
        if (other.CompareTag("NPC5_Sub")) { npc5_sub = false; Q5_sub.enabled = false; }

        if (other.CompareTag("NPC1_Mult")) { npc1_mult = false; Q1_mult.enabled = false; }
        if (other.CompareTag("NPC2_Mult")) { npc2_mult = false; Q2_mult.enabled = false; }
        if (other.CompareTag("NPC3_Mult")) { npc3_mult = false; Q3_mult.enabled = false; }
        if (other.CompareTag("NPC4_Mult")) { npc4_mult = false; Q4_mult.enabled = false; }
        if (other.CompareTag("NPC5_Mult")) { npc5_mult = false; Q5_mult.enabled = false; }

    }
}
