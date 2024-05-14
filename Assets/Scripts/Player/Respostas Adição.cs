using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasAdição : MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5;
    public Collider meuColisor1, meuColisor5;
    public Animator npc1_animator, npc2_animator, npc3_animator, npc4_animator, npc5_animator;
    public TMP_InputField res2, res3, res4;
    public GameObject excl1, excl2, excl3, excl4, excl5;
    public TMP_Text r2text, r3text, r4text;
    private bool r1ok, r2ok, r3ok, r4ok, r5ok;

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

    void Update()
    {
        if (!r1ok) { R1(); }
        if (!r5ok) { R5(); }

    }

   void R1(){

        HashSet<Collider> pedrasColidindo = new HashSet<Collider>();

        Collider[] objetosColidindo = Physics.OverlapBox(meuColisor1.bounds.center, meuColisor1.bounds.extents, Quaternion.identity);
 
        foreach (Collider col in objetosColidindo)
        {
            if (col.CompareTag("Pedra_1"))
            {
                pedrasColidindo.Add(col);

            }
        }

        if (pedrasColidindo.Count == 5)
        {
            r1.enabled = true;
            npc1_animator.SetBool("NPC1_right", true);
            q1.gameObject.SetActive(false);
            excl1.gameObject.SetActive(false); 
            r1ok = true;
        }

    }
    public void R2() {
        if (res2.text == "20")
        {
            r2text.text = "Ah, isso mesmo!! muito bem!";
            r2.enabled = true;
            npc2_animator.SetBool("NPC1_right", true);
            q2.gameObject.SetActive(false);
            excl2.gameObject.SetActive(false);
            r2ok = true;
        }
        else
        {
            r2text.text =  "Uhmm...acho que não é esse valor";
            r2.enabled = true;
        }
    }

    public void R3() {
        if (res3.text == "13")
        {
            r3text.text = "Claro, 13 litros no total!";
            r3.enabled = true;
            npc3_animator.SetBool("NPC3_right", true);
            q3.gameObject.SetActive(false);
            excl3.gameObject.SetActive(false);
            r3ok = true;
        }
        else
        {
            r3text.text = "Tem certeza? Me parece que não é essa quantidade...";
            r3.enabled = true;
        }

    }

    public void R4()
    {
        if (res4.text == "15")
        {
            r4text.text = "Que ótimo! É justamente a quantia que preciso";
            r4.enabled = true;
            npc4_animator.SetBool("NPC3_right", true);
            q4.gameObject.SetActive(false);
            excl4.gameObject.SetActive(false);
            r4ok = true;
        }
        else
        {
            r4text.text = "Não está certo...";
            r4.enabled = true;
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

        if (pratosColidindo.Count == 4)
        {
            r5.enabled = true;
            npc5_animator.SetBool("NPC5_right", true);
            q5.gameObject.SetActive(false);
            excl5.gameObject.SetActive(false);
            r5ok = true;
        }

    }

}
