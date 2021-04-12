using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public int lives;
    public Text amount;

    void Awake()
    {
        lives = 100;
    }

    // Update is called once per frame
    void Update()
    {
        amount.text = lives.ToString();

        if (lives <= 0)
        {
            SceneManager.LoadScene(sceneName: "Game Over");

        }

    }
}
