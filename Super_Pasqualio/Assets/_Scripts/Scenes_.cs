using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public enum CurrentMenu
{
    Idle,
    Running,
    GameOver
}
public class Scenes_ : MonoBehaviour
{
    public static Scenes_ S;

    [Header("Set in Inspector")]
    public Button startGameBtn;
    public Button exitGameBtn;

    public CurrentMenu currentMenu = CurrentMenu.Idle;
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        S = this;
    }

    public void LoadIntro()
    {
         SceneManager.LoadScene("IntroScene");
    }

    public void LoadGame()
    {
        currentMenu = CurrentMenu.Running;

        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        currentMenu = CurrentMenu.GameOver;
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; 
#endif
        Application.Quit();
    }

    public void LoadGameOver()
    {
        currentMenu = CurrentMenu.GameOver;
        SceneManager.LoadScene("EndScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
