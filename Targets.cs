using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Targets : MonoBehaviour
{
    private Rigidbody targetRB;
    private float xPos = 7f;
    public int point;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        transform.position = new Vector3(GetRandomValue(xPos), -2); // start spawn position all targets 
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(Vector3.up * GenerateSpeed(), ForceMode.Impulse);
        targetRB.AddTorque(GetRandomValue(10), GetRandomValue(15), GetRandomValue(12), ForceMode.Impulse);
        
        
    }

    // Update is called once per frame
    void Update()   
    {
        
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(point);
        Instantiate(gameManager.explosion, transform.position, gameManager.explosion.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    private float GenerateSpeed()
    {
        return Random.Range(13.0f, 16.0f);
    }
    private float GetRandomValue(float value)
    {
        return Random.Range(-value, value);
    }
    
}

