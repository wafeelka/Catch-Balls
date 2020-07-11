using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public ParticleSystem explosion;
    private const float spanTime = 2.5f;
    
    public TextMeshProUGUI scoreText;
     int score;

    void Start()
    {
        score = 0;
        StartCoroutine(spawnTarget());
        UpdateScore(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spanTime);
            int index = Random.Range(0, gameObjects.Count);
            Instantiate(gameObjects[index]);
        }
       
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

    }
}
