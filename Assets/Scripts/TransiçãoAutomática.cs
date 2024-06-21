using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor.SearchService;

public class TransiçãoAutomática : MonoBehaviour
{
    public float waitTime;
    public Transição transição;
    string scenetoGo;

    void Start (){
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Capa") { scenetoGo = "Intro"; }
        StartCoroutine(TimetoFade());
    }

    private IEnumerator TimetoFade()
    {
        yield return new WaitForSeconds(waitTime);
        transição = GameObject.FindObjectOfType<Transição>();
        transição.TransitionToScene(scenetoGo);

    }
}
