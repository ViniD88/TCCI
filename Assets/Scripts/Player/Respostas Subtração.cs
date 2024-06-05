using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasSubtração: MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5;
    public Animator npc1_animator, npc2_animator, npc3_animator, npc4_animator, npc5_animator;
    public TMP_InputField res1, res2, res3, res4;
    public GameObject excl1, excl2, excl3, excl4, excl5;
    public TMP_Text r1text, r2text, r3text, r4text;
    private bool r1ok, r2ok, r3ok, r4ok, r5ok;
    public List<bool> questoesCertas;
    public GameObject NPC2;
    public Rigidbody npc2Rb;

    void Start()
    {
        r1.enabled = false;
        r1ok = false;
        r2.enabled = false;
        r2ok = false;
        r3.enabled = false;
        r3ok = false;
        r4.enabled = false;
        r4ok = false;
        r5.enabled = false;
        r5ok = false;

    }

    private void Update()
    {
        if (r2ok) {
            npc2Rb = NPC2.GetComponent<Rigidbody>();
            npc2Rb.isKinematic = false;
        }
    }

    public void R1()
    {
        if (res1.text == "6")
        {
            r1text.text = "Ah sim, isso mesmo!";
            r1.enabled = true;
            q1.gameObject.SetActive(false);
            excl1.gameObject.SetActive(false);
            r1ok = true;
            questoesCertas.Add(r1ok);
        }
        else
        {
            r1text.text = "Acho q não.";
            r1.enabled = true;
        }
    }

        public void R2() {
        if (res2.text == "3")
        {
            r2text.text = "Legal, então posso pular!";
            r2.enabled = true;
            npc2_animator.SetBool("NPC2_sub", true);
            q2.gameObject.SetActive(false);
            excl2.gameObject.SetActive(false);
            r2ok = true;
            questoesCertas.Add(r2ok);
        }
        else
        {
            r2text.text =  "Uhmm...acho que não eim...";
            r2.enabled = true;
        }
    }


}
