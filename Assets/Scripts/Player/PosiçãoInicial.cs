using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosiçãoInicial : MonoBehaviour
{

    public GameObject Player;

    void Start()
    {
        
        if (PlayerPrefs.HasKey("X") && PlayerPrefs.HasKey("Y") && PlayerPrefs.HasKey("Z"))
        {
            Player.transform.localPosition = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
        }

        Physics.SyncTransforms();

    }

}
