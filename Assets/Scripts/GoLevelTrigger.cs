using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoLevelTrigger : MonoBehaviour {
    [SerializeField]
    private string level;

    
    void OnTriggerEnter2D()
    {       
        SceneManager.LoadScene(level);     
    }
}
