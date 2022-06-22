using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;

    public float spawnTime;

    float m_spawnTime;

    int m_score;

    bool m_isGameover;

    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover)
        {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }

        m_spawnTime -= Time.deltaTime;

        if(m_spawnTime <= 0)
        {
            SpawnEnemy();

            m_spawnTime = spawnTime;
        }
    }

    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-6f, 6f);

        Vector2 spawnPos = new Vector2(randXpos, 7);

        if(enemy)
        {
            Instantiate(enemy ,spawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    {
        return m_score;
    }

    public void ScoreIncrement()
    {
        if (m_isGameover)
        {
            return;
        }

        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }

    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }

    public bool IsGameover()
    {
        return m_isGameover;
    }


}
