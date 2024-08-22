using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasMultiplicação: MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5;
    public Collider Colisor1, Colisor5;
    public Animator npc1_animator, npc2_animator, npc3_animator, npc4_animator, npc5_animator;
    public TMP_InputField res2, res3, res4;
    public GameObject excl1, excl2, excl3, excl4, excl5;
    public TMP_Text r1text, r2text, r3text, r4text, r5text;
    private bool r1ok, r2ok, r3ok, r4ok, r5ok;
    public List<bool> questoesCertas;
    public int Q1mul, Q2mul, Q3mul, Q4mul, Q5mul;

    void Start()
    {
        r1.enabled = false;
        r2.enabled = false;
        r3.enabled = false;
        r4.enabled = false;
        r5.enabled = false;

        if (PlayerPrefs.GetInt("Q2_mul") == 1)
        {
            R2();
        }

        if (PlayerPrefs.GetInt("Q3_mul") == 1)
        {
            R3();
        }

        if (PlayerPrefs.GetInt("Q4_mul") == 1)
        {
            R4();
        }

    }

    private void Update()
    {
        if (!r1ok) { R1(); }
        if (!r5ok) { R5(); }
    }

    public void R1()
    {
        HashSet<Collider> sacosColidindo = new HashSet<Collider>();

        Collider[] objetosColidindo = Physics.OverlapBox(Colisor1.bounds.center, Colisor1.bounds.extents, Quaternion.identity);

        foreach (Collider col in objetosColidindo)
        {
            if (col.CompareTag("bag"))
            {
                sacosColidindo.Add(col);

            }
        }

        if (sacosColidindo.Count == 6 || PlayerPrefs.GetInt("Q1_mul") == 1)
        {
            if (PlayerPrefs.GetInt("Q1_mul") != 1) { r1.enabled = true; }
            npc1_animator.SetBool("NPC1_right", true);
            q1.gameObject.SetActive(false);
            excl1.gameObject.SetActive(false);
            r1ok = true;
            Q1mul = 1;
            questoesCertas.Add(r1ok);
        }
    }

    public void R2()
    {
        if (res2.text == "400" || PlayerPrefs.GetInt("Q2_mul") == 1)
        {
            r2text.text = "Obrigada! Daqui a pouco irei para lá.";
            if (PlayerPrefs.GetInt("Q2_mul") != 1) { r2.enabled = true; }
            npc2_animator.SetBool("NPC3_right", true);
            q2.gameObject.SetActive(false);
            excl2.gameObject.SetActive(false);
            r2ok = true;
            Q2mul = 1;
            questoesCertas.Add(r2ok);
        }
        else
        {
            r2text.text = "Acredito que não seja isso...";
            r2.enabled = true;
            q2.enabled = false;
        }
    }

    public void R3()
    {
        if (res3.text == "21" || PlayerPrefs.GetInt("Q3_mul") == 1)
        {
            r3text.text = "Muito bem!";
            if (PlayerPrefs.GetInt("Q3_mul") != 1) { r3.enabled = true; }
            npc3_animator.SetBool("NPC5_right", true);
            q3.gameObject.SetActive(false);
            excl3.gameObject.SetActive(false);
            r3ok = true;
            Q3mul = 1;
            questoesCertas.Add(r3ok);
        }
        else
        {
            r3text.text = "Esse valor não está certo.";
            r3.enabled = true;
            q3.enabled = false;
        }

    }

    public void R4()
    {
        if (res4.text == "12" || PlayerPrefs.GetInt("Q4_mul") == 1)
        {
            r4text.text = "Sim! Agora vai ficar ótimo";
            if (PlayerPrefs.GetInt("Q4_mul") != 1) { r4.enabled = true; }
            npc4_animator.SetBool("NPC3_right", true);
            q4.gameObject.SetActive(false);
            excl4.gameObject.SetActive(false);
            r4ok = true;
            Q4mul = 1;
            questoesCertas.Add(r4ok);
        }
        else
        {
            r4text.text = "Desse jeito não vai ficar bom...";
            r4.enabled = true;
            q4.enabled = false;
        }

    }

    public void R5()
    {
        HashSet<Collider> cogumelosColidindo = new HashSet<Collider>();

        Collider[] objetosColidindo = Physics.OverlapBox(Colisor5.bounds.center, Colisor5.bounds.extents, Quaternion.identity);

        foreach (Collider col in objetosColidindo)
        {
            if (col.CompareTag("cogumelos"))
            {
                cogumelosColidindo.Add(col);

            }
        }

        if (cogumelosColidindo.Count == 6 || PlayerPrefs.GetInt("Q5_mul") == 1)
        {
            if (PlayerPrefs.GetInt("Q5_mul") != 1) { r5.enabled = true; }
            npc5_animator.SetBool("NPC1_right", true);
            q5.gameObject.SetActive(false);
            excl5.gameObject.SetActive(false);
            r5ok = true;
            Q5mul = 1;
            questoesCertas.Add(r5ok);
        }
    }


}
