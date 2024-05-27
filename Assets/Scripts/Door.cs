using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public Animator anim;
	public bool SubOK, MultOk, DivOk;
    public RespostasAdição respostasAdição;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        SubOK = false;
        MultOk = false;
        DivOk = false;
    }

	void OnTriggerEnter (Collider other) {
		if (this.tag == "Gate")
		{
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClose", false);
        }

        if (this.tag == "GateSub" && SubOK == true)
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClose", false);
        }

	}

	void OnTriggerExit (Collider other) {
        if (this.tag == "Gate")
        {
            anim.SetBool("DoorOpen", false);
            anim.SetBool("DoorClose", true);
        }

        if (this.tag == "GateSub" && SubOK == true)
        {
            anim.SetBool("DoorOpen", false);
            anim.SetBool("DoorClose", true);
        }
    }

	void Update () {
		if (respostasAdição.questoesCertas.Count == 5) {
			SubOK = true;
        }
	}
}
