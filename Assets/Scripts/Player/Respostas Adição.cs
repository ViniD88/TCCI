using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasAdição : MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5, q6, r6;
    public Collider meuColisor1, meuColisor5;
    public Animator npc1_animator, npc2_animator, npc3_animator, npc4_animator, npc5_animator;
    public TMP_InputField res2, res3, res4, res6;
    public GameObject excl1, excl2, excl3, excl4, excl5, excl6;
    public TMP_Text r2text, r3text, r4text, r6text;
    public bool r1ok, r2ok, r3ok, r4ok, r5ok, r6ok;
    public List<bool> questoesCertas;
    public int Q1ad, Q2ad, Q3ad, Q4ad, Q5ad, Q6ad;
    public AudioSource certo, errado;

    void Start()
    {
        r1.enabled = false;
        r2.enabled = false;
        r3.enabled = false;
        r4.enabled = false;
        r5.enabled = false;
        r6.enabled = false;

        if (PlayerPrefs.GetInt("Q2_ad") == 1)
        {
            R2();
        }

        if (PlayerPrefs.GetInt("Q3_ad") == 1)
        {
            R3();
        }

        if (PlayerPrefs.GetInt("Q4_ad") == 1)
        {
            R4();
        }

        if (PlayerPrefs.GetInt("Q6_ad") == 1)
        {
            R6();
        }

    }

    void Update()
    {
        if (!r1ok) { R1(); }
        if (!r5ok) { R5(); }
    }

   public void R1(){

        HashSet<Collider> pedrasColidindo = new HashSet<Collider>();

        Collider[] objetosColidindo = Physics.OverlapBox(meuColisor1.bounds.center, meuColisor1.bounds.extents, Quaternion.identity);
 
        foreach (Collider col in objetosColidindo)
        {
            if (col.CompareTag("Pedra_1"))
            {
                pedrasColidindo.Add(col);

            }
        }

        if (pedrasColidindo.Count == 5 || PlayerPrefs.GetInt("Q1_ad")==1)
        {
            if (PlayerPrefs.GetInt("Q1_ad") != 1) { r1.enabled = true; }
            npc1_animator.SetBool("NPC1_right", true);
            q1.gameObject.SetActive(false);
            excl1.gameObject.SetActive(false); 
            r1ok = true;
            Q1ad = 1;
            questoesCertas.Add(r1ok);
            certo.Play();

        }

    }
    public void R2() {
        if (res2.text == "20" || PlayerPrefs.GetInt("Q2_ad") == 1)
        {
            r2text.text = "Ah, isso mesmo!! muito bem!";
            if (PlayerPrefs.GetInt("Q2_ad") != 1) { r2.enabled = true; }
            npc2_animator.SetBool("NPC1_right", true);
            q2.gameObject.SetActive(false);
            excl2.gameObject.SetActive(false);
            r2ok = true;
            Q2ad = 1;
            questoesCertas.Add(r2ok);
            certo.Play();
        }
        else
        {
            r2text.text =  "Uhmm...acho que não é esse valor";
            q2.enabled = false;
            r2.enabled = true;
            errado.Play();
        }
    }

    public void R3() {
        if (res3.text == "13" || PlayerPrefs.GetInt("Q3_ad") == 1)
        {
            r3text.text = "Claro, 13 litros no total!";
            if (PlayerPrefs.GetInt("Q3_ad") != 1) { r3.enabled = true; }
            npc3_animator.SetBool("NPC3_right", true);
            q3.gameObject.SetActive(false);
            excl3.gameObject.SetActive(false);
            r3ok = true;
            Q3ad = 1;
            questoesCertas.Add(r3ok);
            certo.Play();
        }
        else
        {
            r3text.text = "Tem certeza? Me parece que não é essa quantidade...";
            r3.enabled = true;
            q3.enabled = false;
            errado.Play();

        }

    }

    public void R4()
    {
        if (res4.text == "15" || PlayerPrefs.GetInt("Q4_ad") == 1)
        {
            r4text.text = "Que ótimo! É justamente a quantia que preciso";
            if (PlayerPrefs.GetInt("Q4_ad") != 1) { r4.enabled = true; }
            npc4_animator.SetBool("NPC3_right", true);
            q4.gameObject.SetActive(false);
            excl4.gameObject.SetActive(false);
            r4ok = true;
            Q4ad = 1;
            questoesCertas.Add(r4ok);
            certo.Play();
        }
        else
        {
            r4text.text = "Não está certo...";
            r4.enabled = true;
            q4.enabled = false;
            errado.Play();

        }

    }

    void R5()
    {

        HashSet<Collider> pratosColidindo = new HashSet<Collider>();

        Collider[] objetosColidindo = Physics.OverlapBox(meuColisor5.bounds.center, meuColisor5.bounds.extents, Quaternion.identity);

        foreach (Collider col in objetosColidindo)
        {
            if (col.CompareTag("Prato"))
            {
                pratosColidindo.Add(col);

            }
        }

        if (pratosColidindo.Count == 4 || PlayerPrefs.GetInt("Q5_ad") == 1)
        {
            if (PlayerPrefs.GetInt("Q5_ad") != 1) { r5.enabled = true; }
            npc5_animator.SetBool("NPC5_right", true);
            q5.gameObject.SetActive(false);
            excl5.gameObject.SetActive(false);
            r5ok = true;
            Q5ad = 1;
            questoesCertas.Add(r5ok);
            certo.Play();
        }

    }

    public void R6()
    {
        if (res6.text == "18" || PlayerPrefs.GetInt("Q6_ad") == 1)
        {
            r6text.text = "Isso mesmo! Agora posso dormir!";
            if (PlayerPrefs.GetInt("Q6_ad") != 1) { r6.enabled = true; }
            q6.gameObject.SetActive(false);
            excl6.gameObject.SetActive(false);
            r6ok = true;
            Q6ad = 1;
            questoesCertas.Add(r6ok);
            certo.Play();
        }
        else
        {
            r6text.text = "Ai, ai, ai, desse jeito não vou dormir!";
            r6.enabled = true;
            q6.enabled = false;
            errado.Play();

        }

    }

}
