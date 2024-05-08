using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RespostasAdição : MonoBehaviour
{
    public Canvas q1, r1, q2, r2, q3, r3, q4, r4, q5, r5;
    public Collider meuColisor1;
    public Animator npc1_animator, npc2_animator;
    public TMP_InputField res2;
    public GameObject excl1, excl2, excl3, excl4, excl5;
    public TMP_Text r2text;
    private bool r1ok, r2ok, r3ok, r4ok, r5ok;

    void Start()
    {
        r1.enabled = false;
        r1ok = false;
        r2.enabled = false;
        r2ok = false;
        r3.enabled = false;
        r3ok = false;

    }

    void Update()
    {
        if (!r1ok) { R1(); }
        

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


}
