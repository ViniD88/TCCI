using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasMultiplicação: MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5;
    public Collider meuColisor1;
    public Animator npc1_animator, npc2_animator, npc3_animator, npc4_animator, npc5_animator;
    public TMP_InputField res2, res3, res4, res5;
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

    private void Update()
    {

        if (!r1ok) { R1(); }
    }

    public void R1()
    {
        HashSet<Collider> sacosColidindo = new HashSet<Collider>();

        Collider[] objetosColidindo = Physics.OverlapBox(meuColisor1.bounds.center, meuColisor1.bounds.extents, Quaternion.identity);

        foreach (Collider col in objetosColidindo)
        {
            if (col.CompareTag("bag"))
            {
                sacosColidindo.Add(col);

            }
        }

        if (sacosColidindo.Count == 6)
        {
            r1.enabled = true;
            npc1_animator.SetBool("NPC1_right", true);
            q1.gameObject.SetActive(false);
            excl1.gameObject.SetActive(false);
            r1ok = true;
            questoesCertas.Add(r1ok);
        }
    }

    public void R2()
    {
        if (res2.text == "400")
        {
            r2text.text = "Obrigada! Daqui a pouco irei para lá.";
            r2.enabled = true;
            npc2_animator.SetBool("NPC3_right", true);
            q2.gameObject.SetActive(false);
            excl2.gameObject.SetActive(false);
            r2ok = true;
            questoesCertas.Add(r2ok);
        }
        else
        {
            r2text.text = "Acredito que não seja isso...";
            r2.enabled = true;
        }
    }

    public void R3()
    {
        if (res3.text == "21")
        {
            r3text.text = "Muito bem!";
            r3.enabled = true;
            npc3_animator.SetBool("NPC5_right", true);
            q3.gameObject.SetActive(false);
            excl3.gameObject.SetActive(false);
            r3ok = true;
            questoesCertas.Add(r3ok);
        }
        else
        {
            r3text.text = "Esse valor não está certo.";
            r3.enabled = true;
        }

    }

    public void R4()
    {
        if (res4.text == "12")
        {
            r4text.text = "Sim! Agora vai ficar ótimo";
            r4.enabled = true;
            npc4_animator.SetBool("NPC2_right", true);
            q4.gameObject.SetActive(false);
            excl4.gameObject.SetActive(false);
            r4ok = true;
            questoesCertas.Add(r4ok);
        }
        else
        {
            r4text.text = "Desse jeito não vai ficar bom...";
            r4.enabled = true;
        }

    }


}
