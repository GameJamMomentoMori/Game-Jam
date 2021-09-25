using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState {Spawning, Waiting, Counting}

    //defining a wave through a seperate class
    //Name of wave, enemy input (can expand for multiple enemy types), Number of enemies, rate enemies spawn
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int Enemies;
        public float rate; 
    }

    //array of Wave class object that can be edited in unity because that class is Serializable
    public Wave[] waves;

    //store the index of the next wave to be used
    private int nextWave = 0;

    public Transform[] spawnPoints;

    //time between waves in seconds
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;

    void Start()
    {
        //check to make sure that some spawn points are referenced
        if(spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }

        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {

        if(state == SpawnState.Waiting)
        {
            //Check if enemies are still alive
            if(!EnemyIsAlive())
            {
                //Begin a new round
                WaveCompleted();
            }

            else
            {
                return;
            }

        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.Spawning)
            {
                //Start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            //timer will decrease relevant to time rather than frames
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        //if the next wave is out of bounds on the array
        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves Complete! Looping...");

        }

        else
        {
            nextWave++;
        }
    }

    //method to check if enemies remain on the scene
    bool EnemyIsAlive()
    {
        //Add a countdown as this is a high CPU process that shouldnt be done every frame
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
            return true;
    }

    //A method for spawning the waves specified in the list
    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.Spawning;

        //Spawn enemies
        for(int i = 0; i < _wave.Enemies; i++)
        {
            SpawnEmemy(_wave.enemy);

            //Wait between enemy spawns based upon the rate of enemy spawn
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        Debug.Log("Done Spawning");

        //Set the spawn state to waiting while the player kills the enemies
        state = SpawnState.Waiting;
        yield break;
    }

    void SpawnEmemy(Transform _enemy)
    {

        //pick a random spawn point to spawn the enemy at
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        //Spawn a new enemy object
        Instantiate(_enemy, _sp.position, _sp.rotation);

        //Spawn Enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
    }

}
