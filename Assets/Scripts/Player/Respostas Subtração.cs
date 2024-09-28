using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasSubtração: MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5, q6, r6;
    public Collider meuColisor4;
    public Animator npc1_animator, npc2_animator, npc3_animator, npc4_animator, npc5_animator, npc6_animator;
    public TMP_InputField res1, res2, res3, res5, res6;
    public GameObject excl1, excl2, excl3, excl4, excl5, excl6;
    public TMP_Text r1text, r2text, r3text, r4text, r5text, r6text;
    private bool r1ok, r2ok, r3ok, r4ok, r5ok, r6ok;
    public List<bool> questoesCertas;
    public GameObject NPC2;
    public Rigidbody npc2Rb;
    public int Q1sub, Q2sub, Q3sub, Q4sub, Q5sub, Q6sub;
    public AudioSource certo, errado;

    void Start()
    {
        r1.enabled = false;
        r2.enabled = false;
        r3.enabled = false;
        r4.enabled = false;
        r5.enabled = false;
        r6.enabled = false;

        if (PlayerPrefs.GetInt("Q1_sub") == 1)
        {
            R1();
        }

        if (PlayerPrefs.GetInt("Q2_sub") == 1)
        {
            R2();
        }

        if (PlayerPrefs.GetInt("Q3_sub") == 1)
        {
            R3();
        }

        if (PlayerPrefs.GetInt("Q5_sub") == 1)
        {
            R5();
        }

        if (PlayerPrefs.GetInt("Q6_sub") == 1)
        {
            R6();
        }

    }

    private void Update()
    {

        if (r2ok) {
            npc2Rb = NPC2.GetComponent<Rigidbody>();
            npc2Rb.isKinematic = false;
        }

        if (!r4ok) { R4();}

    }

    public void R1()
    {
        if (res1.text == "6" || PlayerPrefs.GetInt("Q1_sub") == 1)
        {
            r1text.text = "Ah sim, isso mesmo!";
            if (PlayerPrefs.GetInt("Q1_sub") != 1) { r1.enabled = true; }
            q1.gameObject.SetActive(false);
            excl1.gameObject.SetActive(false);
            r1ok = true;
            Q1sub = 1;
            questoesCertas.Add(r1ok);
            certo.Play();
        }
        else
        {
            r1text.text = "Ué, achei que fosse outro número.";
            r1.enabled = true;
            q1.enabled = false;
            errado.Play();
        }
    }

    public void R2() {
        if (res2.text == "3" || PlayerPrefs.GetInt("Q2_sub") == 1)
        {
            r2text.text = "Legal, então posso pular!";
            if (PlayerPrefs.GetInt("Q2_sub") != 1) { r2.enabled = true; }
            npc2_animator.SetBool("NPC2_sub", true);
            q2.gameObject.SetActive(false);
            excl2.gameObject.SetActive(false);
            r2ok = true;
            Q2sub = 1;
            questoesCertas.Add(r2ok);
            certo.Play();
        }
        else
        {
            r2text.text =  "Uhmm...acho que não eim...";
            r2.enabled = true;
            q2.enabled = false;
            errado.Play();
        }
    }

    public void R3()
    {
        if (res3.text == "7" || PlayerPrefs.GetInt("Q3_sub") == 1)
        {
            r3text.text = "Uhm, falta um pouco mais da metade. Obrigada!";
            if (PlayerPrefs.GetInt("Q3_sub") != 1) { r3.enabled = true; }
            npc3_animator.SetBool("NPC3_right", true);
            q3.gameObject.SetActive(false);
            excl3.gameObject.SetActive(false);
            r3ok = true;
            Q3sub = 1;
            questoesCertas.Add(r3ok);
            certo.Play();
        }
        else
        {
            r3text.text = "Será? Não acho que seja essa quantia";
            r3.enabled = true;
            q3.enabled = false;
            errado.Play();
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

        if (barrisColidindo.Count == 4 || PlayerPrefs.GetInt("Q4_sub") == 1)
        {
            if (PlayerPrefs.GetInt("Q4_sub") != 1) { r4.enabled = true; }
            npc4_animator.SetBool("NPC3_right", true);
            q4.gameObject.SetActive(false);
            excl4.gameObject.SetActive(false);
            r4ok = true;
            Q4sub = 1;
            questoesCertas.Add(r4ok);
            certo.Play();
        }

    }

    public void R5()
    {
        if (res5.text == "4" || PlayerPrefs.GetInt("Q5_sub") == 1)
        {
            r5text.text = "Certo então! Obrigado!";
            if (PlayerPrefs.GetInt("Q5_sub") != 1) { r5.enabled = true; }
            npc5_animator.SetBool("NPC1_right", true);
            q5.gameObject.SetActive(false);
            excl5.gameObject.SetActive(false);
            r5ok = true;
            Q5sub = 1;
            questoesCertas.Add(r5ok);
            certo.Play();
        }
        else
        {
            r5text.text = "Acho que não. Desse jeito ela vai brigar comigo.";
            r5.enabled = true;
            q5.enabled = false;
            errado.Play();
        }
    }

    public void R6()
    {
        if (res6.text == "30" || PlayerPrefs.GetInt("Q6_sub") == 1)
        {
            r6text.text = "Exato! Muito bem!";
            if (PlayerPrefs.GetInt("Q6_sub") != 1) { r6.enabled = true; }
            npc6_animator.SetBool("NPC5_right", true);
            q6.gameObject.SetActive(false);
            excl6.gameObject.SetActive(false);
            r6ok = true;
            Q6sub = 1;
            questoesCertas.Add(r6ok);
            certo.Play();
        }
        else
        {
            r6text.text = "Não é isso não...";
            r6.enabled = true;
            q6.enabled = false;
            errado.Play();
        }
    }

}
