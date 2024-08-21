using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosiçãoInicial : MonoBehaviour
{

    public GameObject Player;
    private bool carregou;

    void Start()
    {
        
        if (PlayerPrefs.HasKey("X") && PlayerPrefs.HasKey("Y") && PlayerPrefs.HasKey("Z") && carregou == false)
        {
            Player.transform.localPosition = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
            carregou = true;
        }

        Physics.SyncTransforms();

    }

}
