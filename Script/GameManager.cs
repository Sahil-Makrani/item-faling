using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject crate;
    [SerializeField] private float maxx;
    [SerializeField] private float spawnRate;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject tapText;

    int score = 0;

    bool gameStarted = false;


    private void Update()
    {
        if(Input.GetMouseButton(0) && !gameStarted)
        {
            startSpawn();
            gameStarted = true;
            tapText.SetActive(false);
        }
    }



    private void startSpawn()
    {
        InvokeRepeating("spawnCrate", 0.5f, spawnRate);
    }

    private void spawnCrate()
    {
        Vector2 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxx, maxx);
        Instantiate(crate,spawnPos,Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
    }

}
