using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState {Spawning, Waiting, Counting}
    public WaveCount WCount;
    public GameObject WaveCountOBJ;
    public DialogManager dialog;

    //IANS CHANGES
    //Wave enemy and enemy count vars are now arrays. can define 
    //enemy types to spawn and enemy counts per enemy type
    //creating a wave with mismatching array lengths returns an error and doesnt spawn
    //a wave

    //defining a wave through a seperate class
    //Name of wave, enemy input (can expand for multiple enemy types), Number of enemies, rate enemies spawn
    [System.Serializable]
    public class Wave
    {
        public string name;
        [Header("Enemy Prefabs to spawn")]
        public Transform[] enemy;
        [Header("Number of enemies per type")]
        public int[] Enemies;
        public float rate; 
    }

    //array of Wave class object that can be edited in unity because that class is Serializable
    public Wave[] waves;

    //store the index of the next wave to be used
    private int nextWave = 0;

    public Transform[] spawnPoints;
    //public GameObject[] enemies;

    //time between waves in seconds
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;

    void Start()
    {
        StartCoroutine(SetWaveNumber());
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

            // Increment the wave counter on the HUD
            WCount.NextWave();
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
        if (!dialog.dialogDone) {
            yield return new WaitForSeconds(10f);
        }

        if(_wave.enemy.Length != _wave.Enemies.Length){
            Debug.LogError("Unable to Spawn Wave: " + _wave.name + ". Enemy types array and enemy count array sizes do not match.");    
        }
        else if(_wave.enemy.Length == _wave.Enemies.Length){
            Debug.Log("Spawning Wave: " + _wave.name);
            state = SpawnState.Spawning;
            
            for(int h = 0; h < _wave.enemy.Length; h++){
            //Spawn enemies
                for(int i = 0; i < _wave.Enemies[h]; i++){
                    SpawnEnemy(_wave.enemy[h]);
            //Wait between enemy spawns based upon the rate of enemy spawn
                    yield return new WaitForSeconds(1f / _wave.rate);
                }
            }

            Debug.Log("Done Spawning");

        //Set the spawn state to waiting while the player kills the enemies
            state = SpawnState.Waiting;
            yield break;
        }
    }

    void SpawnEnemy(Transform _enemy)
    {

        //pick a random spawn point to spawn the enemy at
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        //Spawn a new enemy object
        Instantiate(_enemy, _sp.position, _sp.rotation);

        //Spawn Enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
    }

    IEnumerator SetWaveNumber(){
        yield return new WaitForSeconds(timeBetweenWaves);
        WCount.SetOne();
    }

}
