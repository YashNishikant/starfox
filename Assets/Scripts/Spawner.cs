
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private GameObject plane;
    [SerializeField] private List<GameObject> rocks;
    [SerializeField] private Text t;
    private int zPos;
    private bool run;
    private int score;
    private float time;


    void Start()
    {
        run = true;
        zPos = 10;
        for (int i = 0; i < count; i++) {
            Instantiate(rocks[Random.Range(0, rocks.Count)], new Vector3(Random.Range(-165, 165), Random.Range(-200, 200), zPos), Quaternion.identity);
            zPos += 5;
        }
    }

    void Update()
    {
        if (!run) { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void spawn() {
        if (run) { 
            Instantiate(rocks[Random.Range(0, rocks.Count)], new Vector3(Random.Range(-165, 165), Random.Range(-200, 200), zPos), Quaternion.identity);
            zPos += 10;
        }
    }

    public void stop()
    {
        run = false;
    }
    public int getScore()
    {
        return score;
    }
    public void msg()
    {
        t.text = "PRESS SPACE";
    }
    public void incScore()
    {
        score++;
        t.text = ""+score;
    }
}
