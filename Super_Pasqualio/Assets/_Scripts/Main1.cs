using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameMode
    {
        Intro,
        Playing,
        End
    }

public class Main1 : MonoBehaviour
{
    static public Main1 S;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;
    public Text ui_score;

    private BoundsCheck bndCheck;

    [Header("Set Dynamically")]
    public int currentScore;

  
    public GameMode mode = GameMode.Intro;

    void Awake()
    {
        S = this;

        bndCheck = GetComponent<BoundsCheck>();
        currentScore = 0;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        if (mode == GameMode.Intro || mode == GameMode.End)
        {
            return;
        }
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        currentScore = 0;
        Scenes_.S.currentMenu = CurrentMenu.GameOver;
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Scenes_.S.currentMenu == CurrentMenu.Idle)
        {
            mode = GameMode.Intro;
        }
        else if (Scenes_.S.currentMenu == CurrentMenu.Running)
        {
            mode = GameMode.Playing;
        }
        else
        {
            if (mode == GameMode.End)
                return;

            mode = GameMode.End;
            SceneManager.LoadScene("EndScene", LoadSceneMode.Additive);
        }


    }
}
