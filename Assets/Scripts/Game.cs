using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame () 
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }
 
    public void QuitGame ()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    public void TestLevel()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }
}
