using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestõesAdição : MonoBehaviour
{
    public Canvas Q1;
    public bool npc1;



    // Start is called before the first frame update
    void Start()
    {
        Q1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (npc1 == true) {
                Q1.enabled = !Q1.enabled;
             }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar se o objeto possui a tag "Coletavel"
        if (other.CompareTag("NPC1"))
        {
            npc1 = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar se o objeto possui a tag "Coletavel"
        if (other.CompareTag("NPC1"))
        {
            npc1 = false;

        }
    }
}
