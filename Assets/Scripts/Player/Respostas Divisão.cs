using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasDivisão: MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5;
    public Collider Colisor, canteiro1, canteiro2, canteiro3;
    public Animator npc1_animator, npc2_animator, npc4_animator, npc5_animator, moinho;
    public TMP_InputField res1, res2, res3, res5;
    public GameObject excl1, excl2, excl3, excl4, excl5;
    public TMP_Text r1text, r2text, r3text, r4text, r5text;
    private bool r1ok, r2ok, r3ok, r4ok, r5ok;
    public List<bool> questoesCertas;



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

    public void Update()
    {
        if (!r4ok) { R4(); }

    }


    public void R1()
    {
        if (res1.text == "6")
        {
            r1text.text = "Valeu, vou começar agorinha!";
            r1.enabled = true;
            npc1_animator.SetBool("NPC1_right", true);
            q1.gameObject.SetActive(false);
            excl1.gameObject.SetActive(false);
            r1ok = true;
            questoesCertas.Add(r1ok);
        }
        else
        {
            r1text.text = "Desse jeito meu chefe não vai gostar.";
            r1.enabled = true;
        }
    }

    public void R2()
    {
        if (res2.text == "8")
        {
            r2text.text = "Obrigada!!";
            r2.enabled = true;
            npc2_animator.SetBool("NPC3_right", true);
            q2.gameObject.SetActive(false);
            excl2.gameObject.SetActive(false);
            r2ok = true;
            questoesCertas.Add(r2ok);
        }
        else
        {
            r2text.text = "Acredito que não seja esse valor.";
            r2.enabled = true;
        }
    }

    public void R3()
    {
        if (res3.text == "5")
        {
            r3text.text = "Ah, isso mesmo!";
            r3.enabled = true;
            q3.gameObject.SetActive(false);
            excl3.gameObject.SetActive(false);
            r3ok = true;
            questoesCertas.Add(r3ok);
        }
        else
        {
            r3text.text = "Tem certeza? Acho que não.";
            r3.enabled = true;
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

        if (floresCanteiro1.Count == 4 && floresCanteiro2.Count == 4 && floresCanteiro3.Count == 4)
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
            r5text.text = "Isso! Veja, o moinho está girando corretamente!";
            r5.enabled = true;
            npc4_animator.SetBool("NPC1_right", true);
            q5.gameObject.SetActive(false);
            excl5.gameObject.SetActive(false);
            r5ok = true;
            questoesCertas.Add(r5ok);
            moinho.speed = 0.25f;
        }
        else
        {
            r5text.text = "Tem certeza? Acho que não.";
            r5.enabled = true;
        }
    }

}
