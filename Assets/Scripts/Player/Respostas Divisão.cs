using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasDivisão: MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5, q6, r6;
    public Collider Colisor, canteiro1, canteiro2, canteiro3;
    public Animator npc1_animator, npc2_animator, npc4_animator, npc5_animator, moinho, npc6_animator;
    public TMP_InputField res1, res2, res3, res5, res6;
    public GameObject excl1, excl2, excl3, excl4, excl5, excl6;
    public TMP_Text r1text, r2text, r3text, r4text, r5text, r6text;
    private bool r1ok, r2ok, r3ok, r4ok, r5ok, r6ok;
    public List<bool> questoesCertas;
    public int Q1div, Q2div, Q3div, Q4div, Q5div, Q6div;
    public AudioSource certo, errado;

    void Start()
    {
        r1.enabled = false;
        r2.enabled = false;
        r3.enabled = false;
        r4.enabled = false;
        r5.enabled = false;
        r6.enabled = false;

        if (PlayerPrefs.GetInt("Q1_div") == 1)
        {
            R1();
        }

        if (PlayerPrefs.GetInt("Q2_div") == 1)
        {
            R2();
        }

        if (PlayerPrefs.GetInt("Q3_div") == 1)
        {
            R3();
        }

        if (PlayerPrefs.GetInt("Q5_div") == 1)
        {
            R5();
        }

        if (PlayerPrefs.GetInt("Q6_div") == 1)
        {
            R6();
        }


    }

    public void Update()
    {

        if (!r4ok) { R4(); }


    }


    public void R1()
    {
        if (res1.text == "6" || PlayerPrefs.GetInt("Q1_div") == 1)
        {
            r1text.text = "Valeu, vou começar agorinha!";
            if (PlayerPrefs.GetInt("Q1_div") != 1) { r1.enabled = true; }
            npc1_animator.SetBool("NPC1_right", true);
            q1.gameObject.SetActive(false);
            excl1.gameObject.SetActive(false);
            r1ok = true;
            Q1div = 1;
            questoesCertas.Add(r1ok);
            certo.Play();
        }
        else
        {
            r1text.text = "Desse jeito meu chefe não vai gostar.";
            r1.enabled = true;
            q1.enabled = false;
            errado.Play();
        }
    }

    public void R2()
    {
        if (res2.text == "8" || PlayerPrefs.GetInt("Q2_div") == 1)
        {
            r2text.text = "Obrigada!!";
            if (PlayerPrefs.GetInt("Q2_div") != 1) { r2.enabled = true; }
            npc2_animator.SetBool("NPC3_right", true);
            q2.gameObject.SetActive(false);
            excl2.gameObject.SetActive(false);
            r2ok = true;
            Q2div = 1;
            questoesCertas.Add(r2ok);
            certo.Play();
        }
        else
        {
            r2text.text = "Acredito que não seja esse valor.";
            r2.enabled = true;
            q2.enabled = false;
            errado.Play();
        }
    }

    public void R3()
    {
        if (res3.text == "5" || PlayerPrefs.GetInt("Q3_div") == 1)
        {
            r3text.text = "Ah, isso mesmo!";
            if (PlayerPrefs.GetInt("Q3_div") != 1) { r3.enabled = true; }
            q3.gameObject.SetActive(false);
            excl3.gameObject.SetActive(false);
            r3ok = true;
            Q3div = 1;
            questoesCertas.Add(r3ok);
            certo.Play();
        }
        else
        {
            r3text.text = "Tem certeza? Acho que não.";
            r3.enabled = true;
            q3.enabled = false;
            errado.Play();
        }
    }

    public void R4()
    {
        HashSet<Collider> floresCanteiro1 = new HashSet<Collider>();
        HashSet<Collider> floresCanteiro2 = new HashSet<Collider>();
        HashSet<Collider> floresCanteiro3 = new HashSet<Collider>();

        Collider[] floresColidindo1 = Physics.OverlapBox(canteiro1.bounds.center, canteiro1.bounds.extents, Quaternion.identity);
        Collider[] floresColidindo2 = Physics.OverlapBox(canteiro2.bounds.center, canteiro2.bounds.extents, Quaternion.identity);
        Collider[] floresColidindo3 = Physics.OverlapBox(canteiro3.bounds.center, canteiro3.bounds.extents, Quaternion.identity);

        foreach (Collider col in floresColidindo1)
        {
            if (col.CompareTag("Flores"))
            {
                floresCanteiro1.Add(col);

            }
        }

        foreach (Collider col in floresColidindo2)
        {
            if (col.CompareTag("Flores"))
            {
                floresCanteiro2.Add(col);

            }
        }

        foreach (Collider col in floresColidindo3)
        {
            if (col.CompareTag("Flores"))
            {
                floresCanteiro3.Add(col);

            }
        }

        if ((floresCanteiro1.Count == 4 && floresCanteiro2.Count == 4 && floresCanteiro3.Count == 4) || PlayerPrefs.GetInt("Q4_div") == 1)
        {
            if (PlayerPrefs.GetInt("Q4_div") != 1) { r4.enabled = true; }
            npc4_animator.SetBool("NPC3_right", true);
            q4.gameObject.SetActive(false);
            excl4.gameObject.SetActive(false);
            r4ok = true;
            Q4div = 1;
            questoesCertas.Add(r4ok);
            certo.Play();
        }

    }

    public void R5()
    {
        if (res5.text == "4" || PlayerPrefs.GetInt("Q5_div") == 1)
        {
            r5text.text = "Isso! Veja, o moinho está girando corretamente!";
            if (PlayerPrefs.GetInt("Q5_div") != 1) { r5.enabled = true; }
            npc5_animator.SetBool("NPC1_right", true);
            q5.gameObject.SetActive(false);
            excl5.gameObject.SetActive(false);
            r5ok = true;
            Q5div = 1;
            questoesCertas.Add(r5ok);
            moinho.speed = 0.25f;
            certo.Play();
        }
        else
        {
            r5text.text = "Tem certeza? Acho que não.";
            r5.enabled = true;
            q5.enabled = false;
            errado.Play();
        }
    }

    public void R6()
    {
        if (res6.text == "5" || PlayerPrefs.GetInt("Q6_div") == 1)
        {
            r6text.text = "Corretíssimo";
            if (PlayerPrefs.GetInt("Q6_div") != 1) { r6.enabled = true; }
            npc6_animator.SetBool("NPC5_right", true);
            q6.gameObject.SetActive(false);
            excl6.gameObject.SetActive(false);
            r6ok = true;
            Q6div = 1;
            questoesCertas.Add(r6ok);
            certo.Play();
        }
        else
        {
            r6text.text = "Não está correto.";
            r6.enabled = true;
            q6.enabled = false;
            errado.Play();
        }
    }

}
