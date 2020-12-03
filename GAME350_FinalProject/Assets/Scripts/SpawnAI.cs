using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAI : MonoBehaviour
{
    public Transform ai;
    public Transform spawnPoint;
    public float timeBetweenSpawn = 10;
    private float spawnCountDown = 3;

    public Text waveCountDownText;

    private int waveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spawnCountDown <= 0)
        {
            // Start spawning AI.
            StartCoroutine(Spawn());
            // Reset the countdown timer.
            spawnCountDown = timeBetweenSpawn;
        }
        // Start counting down as time passes by.
        spawnCountDown -= Time.deltaTime;

        waveCountDownText.text = "Next Wave in: " + Mathf.Round(Mathf.Floor(spawnCountDown)).ToString();
        
    }

    public void SpawnButton()
    {
        if (spawnCountDown <= 0)
        {
            // Start spawning AI.
            StartCoroutine(Spawn());
            // Reset the countdown timer.
            spawnCountDown = timeBetweenSpawn;
        }
        // Start counting down as time passes by.
        spawnCountDown -= Time.deltaTime;
    }

    IEnumerator Spawn()
    {
        waveIndex++;

        Debug.Log("Spawn Started!");
        Instantiate(ai, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(5f);
        
        for (int i = 0; i < waveIndex; i++)
        {
            Instantiate(ai, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}
