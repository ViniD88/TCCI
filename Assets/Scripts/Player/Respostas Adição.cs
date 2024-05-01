using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RespostasAdição : MonoBehaviour
{
    public Canvas r1;
    public Collider meuColisor;
    public int Res;
    public Animator npc1_animator;

    void Start()
    {
        r1.enabled = false;
        meuColisor = GetComponent<Collider>();
        npc1_animator = GameObject.FindGameObjectWithTag("NPC1").GetComponent<Animator>();


    }

    void Update()
    {
        
        R1();
    }

   void R1(){

        HashSet<Collider> pedrasColidindo = new HashSet<Collider>();

        Collider[] objetosColidindo = Physics.OverlapBox(meuColisor.bounds.center, meuColisor.bounds.extents, Quaternion.identity);
 
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
        }

        Res = pedrasColidindo.Count;
    }

}
