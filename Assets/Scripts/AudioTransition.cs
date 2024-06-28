using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioTransition : MonoBehaviour
{

    private void Awake()
    {

        if (FindObjectsOfType<AudioTransition>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
 
        if (scene.name == "Game")
        {
            Destroy(gameObject); 
        }
    }

    private void OnDestroy()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}