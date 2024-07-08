using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasSubtração: MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5;
    public Collider meuColisor4;
    public Animator npc1_animator, npc2_animator, npc3_animator, npc4_animator, npc5_animator;
    public TMP_InputField res1, res2, res3, res5;
    public GameObject excl1, excl2, excl3, excl4, excl5;
    public TMP_Text r1text, r2text, r3text, r4text, r5text;
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

        if (!r4ok) { R4(); }
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
            r1text.text = "Ué, achei que fosse outro número.";
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

    public void R3()
    {
        if (res3.text == "7")
        {
            r3text.text = "Uhm, falta um pouco mais da metade. Obrigada!";
            r3.enabled = true;
            npc3_animator.SetBool("NPC3_right", true);
            q3.gameObject.SetActive(false);
            excl3.gameObject.SetActive(false);
            r3ok = true;
            questoesCertas.Add(r3ok);
        }
        else
        {
            r3text.text = "Será? Não acho que seja essa quantia";
            r3.enabled = true;
        }
    }

    public void R4()
    {

        HashSet<Collider> barrisColidindo = new HashSet<Collider>();

        Collider[] objetosColidindo = Physics.OverlapBox(meuColisor4.bounds.center, meuColisor4.bounds.extents, Quaternion.identity);

        foreach (Collider col in objetosColidindo)
        {
            if (col.CompareTag("Barril"))
            {
                barrisColidindo.Add(col);

            }
        }

        if (barrisColidindo.Count == 4)
        {
            r4.enabled = true;
            npc4_animator.SetBool("NPC3_right", true);
            q4.gameObject.SetActive(false);
            excl4.gameObject.SetActive(false);
            r4ok = true;
            questoesCertas.Add(r4ok);
        }

    }

    public void R5()
    {
        if (res5.text == "4")
        {
            r5text.text = "Certo então! Obrigado!";
            r5.enabled = true;
            npc5_animator.SetBool("NPC1_right", true);
            q5.gameObject.SetActive(false);
            excl5.gameObject.SetActive(false);
            r5ok = true;
            questoesCertas.Add(r5ok);
        }
        else
        {
            r5text.text = "Acho que não. Desse jeito ela vai brigar comigo.";
            r5.enabled = true;
        }
    }

}
