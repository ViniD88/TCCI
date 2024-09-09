using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Questões: MonoBehaviour
{
    public Canvas Q1,Q2,Q3,Q4,Q5,Q6;
    public bool npc1, npc2, npc3, npc4, npc5, npc6;
    public TMP_InputField r2text, r3text, r4text, r6text;
    public Canvas Q1_sub, Q2_sub, Q3_sub, Q4_sub, Q5_sub, Q6_sub;
    public bool npc1_sub, npc2_sub, npc3_sub, npc4_sub, npc5_sub, npc6_sub;
    public TMP_InputField r1_Subtext, r2_Subtext, r3_Subtext, r5_Subtext, r6_Subtext;
    public Canvas Q1_mult, Q2_mult, Q3_mult, Q4_mult, Q5_mult, Q6_mult;
    public bool npc1_mult, npc2_mult, npc3_mult, npc4_mult, npc5_mult, npc6_mult;
    public TMP_InputField r2_Multext, r3_Multext, r4_Multext, r6_Multext;
    public Canvas Q1_div, Q2_div, Q3_div, Q4_div, Q5_div, Q6_div;
    public bool npc1_div, npc2_div, npc3_div, npc4_div, npc5_div, npc6_div;
    public TMP_InputField r1_Divtext, r2_Divtext, r3_Divtext, r5_Divtext, r6_Divtext;


    void Start()
    {
        Q1.enabled = false;
        Q2.enabled = false;
        Q3.enabled = false;
        Q4.enabled = false;
        Q5.enabled = false;
        Q6.enabled = false;

        Q1_sub.enabled = false;
        Q2_sub.enabled = false;
        Q3_sub.enabled = false;
        Q4_sub.enabled = false;
        Q5_sub.enabled = false;
        Q6_sub.enabled = false;


        Q1_mult.enabled = false;
        Q2_mult.enabled = false;
        Q3_mult.enabled = false;
        Q4_mult.enabled = false;
        Q5_mult.enabled = false;
        Q6_mult.enabled = false;

        Q1_div.enabled = false;
        Q2_div.enabled = false;
        Q3_div.enabled = false;
        Q4_div.enabled = false;
        Q5_div.enabled = false;
        Q6_div.enabled = false;
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
                r2text.text = "";
                Q2.enabled = !Q2.enabled;
            }

            if (npc3 == true)
            {
                r3text.text = "";
                Q3.enabled = !Q3.enabled;
            }

            if (npc4 == true)
            {
                r4text.text = "";
                Q4.enabled = !Q4.enabled;
            }

            if (npc5 == true)
            {
                Q5.enabled = !Q5.enabled;
            }

            if (npc6 == true)
            {
                Q6.enabled = !Q6.enabled;
            }

            //questões subtração
            if (npc1_sub == true)
            {
                r1_Subtext.text = "";
                Q1_sub.enabled = !Q1_sub.enabled;
            }

            if (npc2_sub == true)
            {
                r2_Subtext.text = "";
                Q2_sub.enabled = !Q2_sub.enabled;
            }

            if (npc3_sub == true)
            {
                r3_Subtext.text = "";
                Q3_sub.enabled = !Q3_sub.enabled;
            }

            if (npc4_sub == true)
            {
                Q4_sub.enabled = !Q4_sub.enabled;
            }

            if (npc5_sub == true)
            {
                r5_Subtext.text = "";
                Q5_sub.enabled = !Q5_sub.enabled;
            }

            if (npc6_sub == true)
            {
                r6_Subtext.text = "";
                Q6_sub.enabled = !Q6_sub.enabled;
            }

            //questões multiplicação
            if (npc1_mult == true)
            {
                Q1_mult.enabled = !Q1_mult.enabled;
            }

            if (npc2_mult == true)
            {
                r2_Multext.text = "";
                Q2_mult.enabled = !Q2_mult.enabled;
            }

            if (npc3_mult == true)
            {
                r3_Multext.text = "";
                Q3_mult.enabled = !Q3_mult.enabled;
            }

            if (npc4_mult == true)
            {
                r4_Multext.text = "";
                Q4_mult.enabled = !Q4_mult.enabled;
            }

            if (npc5_mult == true)
            {
                Q5_mult.enabled = !Q5_mult.enabled;
            }

            if (npc6_mult == true)
            {
                r6_Multext.text = "";
                Q6_mult.enabled = !Q6_mult.enabled;
            }

            //questões divisão
            if (npc1_div == true)
            {
                r1_Divtext.text = "";
                Q1_div.enabled = !Q1_div.enabled;
            }

            if (npc2_div == true)
            {
                r2_Divtext.text = "";
                Q2_div.enabled = !Q2_div.enabled;
            }

            if (npc3_div == true)
            {
                r3_Divtext.text = "";
                Q3_div.enabled = !Q3_div.enabled;
            }

            if (npc4_div == true)
            {
                Q4_div.enabled = !Q4_div.enabled;
            }

            if (npc5_div == true)
            {
                r5_Divtext.text = "";
                Q5_div.enabled = !Q5_div.enabled;
            }

            if (npc6_div == true)
            {
                r6_Divtext.text = "";
                Q6_div.enabled = !Q6_div.enabled;
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
        if (other.CompareTag("NPC6")) { npc6 = true; }

        if (other.CompareTag("NPC1_Sub")) { npc1_sub = true; }
        if (other.CompareTag("NPC2_Sub")) { npc2_sub = true; }
        if (other.CompareTag("NPC3_Sub")) { npc3_sub = true; }
        if (other.CompareTag("NPC4_Sub")) { npc4_sub = true; }
        if (other.CompareTag("NPC5_Sub")) { npc5_sub = true; }
        if (other.CompareTag("NPC6_Sub")) { npc6_sub = true; }

        if (other.CompareTag("NPC1_Mult")) { npc1_mult = true; }
        if (other.CompareTag("NPC2_Mult")) { npc2_mult = true; }
        if (other.CompareTag("NPC3_Mult")) { npc3_mult = true; }
        if (other.CompareTag("NPC4_Mult")) { npc4_mult = true; }
        if (other.CompareTag("NPC5_Mult")) { npc5_mult = true; }
        if (other.CompareTag("NPC6_Mult")) { npc6_mult = true; }

        if (other.CompareTag("NPC1_Div")) { npc1_div = true; }
        if (other.CompareTag("NPC2_Div")) { npc2_div = true; }
        if (other.CompareTag("NPC3_Div")) { npc3_div = true; }
        if (other.CompareTag("NPC4_Div")) { npc4_div = true; }
        if (other.CompareTag("NPC5_Div")) { npc5_div = true; }
        if (other.CompareTag("NPC6_Div")) { npc6_div = true; }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("NPC1")) { npc1 = false; Q1.enabled = false; }
        if (other.CompareTag("NPC2")) { npc2 = false; Q2.enabled = false; }
        if (other.CompareTag("NPC3")) { npc3 = false; Q3.enabled = false; }
        if (other.CompareTag("NPC4")) { npc4 = false; Q4.enabled = false; }
        if (other.CompareTag("NPC5")) { npc5 = false; Q5.enabled = false; }
        if (other.CompareTag("NPC6")) { npc5 = false; Q6.enabled = false; }

        if (other.CompareTag("NPC1_Sub")) { npc1_sub = false; Q1_sub.enabled = false; }
        if (other.CompareTag("NPC2_Sub")) { npc2_sub = false; Q2_sub.enabled = false; }
        if (other.CompareTag("NPC3_Sub")) { npc3_sub = false; Q3_sub.enabled = false; }
        if (other.CompareTag("NPC4_Sub")) { npc4_sub = false; Q4_sub.enabled = false; }
        if (other.CompareTag("NPC5_Sub")) { npc5_sub = false; Q5_sub.enabled = false; }
        if (other.CompareTag("NPC6_Sub")) { npc6_sub = false; Q6_sub.enabled = false; }

        if (other.CompareTag("NPC1_Mult")) { npc1_mult = false; Q1_mult.enabled = false; }
        if (other.CompareTag("NPC2_Mult")) { npc2_mult = false; Q2_mult.enabled = false; }
        if (other.CompareTag("NPC3_Mult")) { npc3_mult = false; Q3_mult.enabled = false; }
        if (other.CompareTag("NPC4_Mult")) { npc4_mult = false; Q4_mult.enabled = false; }
        if (other.CompareTag("NPC5_Mult")) { npc5_mult = false; Q5_mult.enabled = false; }
        if (other.CompareTag("NPC6_Mult")) { npc6_mult = false; Q6_mult.enabled = false; }

        if (other.CompareTag("NPC1_Div")) { npc1_div = false; Q1_div.enabled = false; }
        if (other.CompareTag("NPC2_Div")) { npc2_div = false; Q2_div.enabled = false; }
        if (other.CompareTag("NPC3_Div")) { npc3_div = false; Q3_div.enabled = false; }
        if (other.CompareTag("NPC4_Div")) { npc4_div = false; Q4_div.enabled = false; }
        if (other.CompareTag("NPC5_Div")) { npc5_div = false; Q5_div.enabled = false; }
        if (other.CompareTag("NPC6_Div")) { npc6_div = false; Q6_div.enabled = false; }

    }
}
