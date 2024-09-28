using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public Animator anim;
    public bool AdOK, SubOK, MultOK, DivOK;
    public RespostasAdição respostasAdição;
    public RespostasSubtração respostasSubtração;
    public RespostasMultiplicação respostasMultiplicação;
    public RespostasDivisão respostasDivisão;
    public UI ui;

    void Start () {
		anim = GetComponent<Animator> ();
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>();
        respostasMultiplicação = GameObject.FindObjectOfType<RespostasMultiplicação>();
        respostasDivisão = GameObject.FindObjectOfType<RespostasDivisão>();
        ui = GameObject.FindObjectOfType<UI>();
        AdOK = false;
        SubOK = false;
        MultOK = false;
        DivOK = false;
    }

	void OnTriggerEnter (Collider other) {
		if (this.tag == "Gate")
		{
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClose", false);
        }

        if (this.tag == "GateSub" && AdOK == true)
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClose", false);
        }

        if (this.tag == "GateMult" && SubOK == true)
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClose", false);
        }

        if (this.tag == "GateDiv" && MultOK == true)
        {
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClose", false);
        }

        if (this.tag == "GateFinish" && DivOK == true)
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

        if (this.tag == "GateSub" && AdOK == true)
        {
            anim.SetBool("DoorOpen", false);
            anim.SetBool("DoorClose", true);
        }

        if (this.tag == "GateMult" && SubOK == true)
        {
            anim.SetBool("DoorOpen", false);
            anim.SetBool("DoorClose", true);
        }

        if (this.tag == "GateDiv" && MultOK == true)
        {
            anim.SetBool("DoorOpen", false);
            anim.SetBool("DoorClose", true);
        }

        if (this.tag == "GateFinish" && DivOK == true)
        {
            anim.SetBool("DoorOpen", false);
            anim.SetBool("DoorClose", true);
        }

    }

    void Update () {
		if (respostasAdição.questoesCertas.Count == ui.totalDesafios)
        {
			AdOK = true;
        }

        if (respostasSubtração.questoesCertas.Count == ui.totalDesafios)
        {
            SubOK = true;
        }


        if (respostasMultiplicação.questoesCertas.Count == ui.totalDesafios)
        {
            MultOK = true;
        }

        if (respostasDivisão.questoesCertas.Count == ui.totalDesafios)
        {
            DivOK = true;
        }
    }
}
