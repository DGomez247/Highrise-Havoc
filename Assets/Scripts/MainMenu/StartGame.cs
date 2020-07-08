using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator musicAnim;

    public float waitTime;
    public void StartButton()
    {
        SceneManager.LoadScene(1);

    }
    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void howToPlay()
    {
        SceneManager.LoadScene(3);
    }
}
