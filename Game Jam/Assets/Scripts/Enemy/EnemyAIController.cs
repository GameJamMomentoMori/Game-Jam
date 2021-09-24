using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    public enum Enemy {Melee,Ranged,Tank,Flying};
    public Enemy currentEnemy;
    [SerializeField] Animator _animator; 
    [Header("Customizable")]
    [SerializeField] float _lookSpeed = 5f;
    [SerializeField] float _distance;
    
    [Header("State")]
    [SerializeField] bool _enemyDead;

    [Header("Navigation")]
    GameObject _player;
    public NavMeshAgent agent;
    
    [Header("Ranged")]
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] GameObject _shotpoint;

    [Header("Attack and Movement Delays")]
    [SerializeField] bool _random;
    [SerializeField] bool _delay;

    [Header("Flying")]
    [SerializeField] GameObject[] _flyEmpties = new GameObject[8];
    [SerializeField] GameObject _projectileGravityPrefab;
    
    CharStat charstat;
    LaunchBall launchball;

    ////
    //#/ Awake function assigns player and accesses
    //#/ character stats from player
    ////
    void Awake()
    {
        _player = GameObject.Find("FirstPersonPlayer");
        charstat = _player.GetComponent<CharStat>();
    }

    ////
    //#/ Start function calls populate enemy
    //#/ if enemy enum is flying
    ////
    void Start(){
        if(currentEnemy == Enemy.Flying){
            PopulateFlyingArray();
        }
    }

    ////
    //#/ Most enemies follow player, so we call that
    //#/ every frame and differentiate enums later inside the function.
    //#/ Ranged is the only enemy that runs from the player.
    ////
    void Update()
    {
        FollowPlayer(currentEnemy);
        
         if(currentEnemy == Enemy.Ranged){
            RunFromPlayer();
        }
    }

    ////
    //#/ This function finds and assigns all player 
    //#/ empty transforms for the flying enemy to move to.
    ////
    void PopulateFlyingArray(){
        for(int i = 0; i < 8; i++){
            _flyEmpties[i] = GameObject.Find("FlyTransform" + i);
            }
    }
    ////
    //#/ FollowPlayer function takes enemy enum parameter and
    //#/ determines AI using passed enum. Melee & tank enemies walk towards player close,
    //#/ ranged enemies start following at a further distance, and flying enemies trigger
    //#/ RandomFlyingPosition to move towards the empties assigned in PopulateFlyingArray.
    ////
    private void FollowPlayer(Enemy enemy){
        _distance = Vector3.Distance(_player.transform.position, this.transform.position);
        
        //if enemy type is melee, enemy is not dead, and 
        //distance is less than two meters, stop and attack
        if(enemy == Enemy.Melee){
            if(_distance < 3f || _enemyDead){
                agent.isStopped = true;
                LookAtPlayer();
                if(_enemyDead == false){
                    if(_delay == false)
                    StartCoroutine(MeleeAttack());
                }
            }
            //if enemy is not within 4 meters, navigate towards player
            if(_distance > 4f){
                agent.isStopped = false;
                agent.SetDestination(_player.transform.position);
            }
        }

         if(enemy == Enemy.Tank){
            if(_distance < 4f || _enemyDead){
                LookAtPlayer();
                agent.isStopped = true;
                if(!_enemyDead ){
                     if(_delay == false)
                        StartCoroutine(TankAttack());
                }
            }
            //if enemy is not within 2 meters, navigate towards player
            else{
                agent.isStopped = false;
                agent.SetDestination(_player.transform.position);
            }
        }

        //if enemy type is ranged, enemy is alive and distance 
        //is greater than 17m, navigate towards the player 
        if(enemy == Enemy.Ranged){
            if(_distance > 17f && !_enemyDead){
                agent.isStopped = false;
                agent.SetDestination(_player.transform.position);
            }
        }
        
        if(enemy == Enemy.Flying){
            LookAtPlayer();
            if(_random == false){
                StartCoroutine(RandomFlyingPosition());
            }
        }
    }

    ////
    //#/ Script used only by ranged enemy. Chooses a runaway position in the
    //#/ opposite direction of player when enemy is too close.
    ////
    private void RunFromPlayer(){
        //if enemy alive and distance between 17-25m, stop and shoot
        if((_distance >= 17f && _distance <= 25f) && !_enemyDead){
            agent.isStopped = true;
            LookAtPlayer();
            if(!_delay){
                StartCoroutine(RangedAttack());
                
            }

            //if enemy is dead stop moving
            if(_enemyDead){
                agent.isStopped = true;
            }
            
        }
        //if enemy is less than 17 meters, run away from player
        else if(_distance < 17f ){
            agent.isStopped = false;
            Vector3 directionToPlayer = transform.position - _player.transform.position;
            Vector3 runAwayPos = transform.position + directionToPlayer;
            agent.SetDestination(runAwayPos);
        }
    }

    ////
    //#/ Random flying position chooses one of eight empty player children from
    //#/ flyEmpties[] and sets it as the AI/s destination at random intervals.
    //#/ Also activates attack script periodically.
    ////
    IEnumerator RandomFlyingPosition(){
        _random = true;
        agent.SetDestination(_flyEmpties[Random.Range(0,_flyEmpties.Length-1)].transform.position);
        yield return new WaitForSeconds(Random.Range(2f,4f));
        StartCoroutine(FlyingAttack());
        _random = false;
    }

    ////
    //#/ LookAtPlayer is only really useful for making Melee player face enemy when
    //#/ super close. Otherwise, AI Navmesh component makes enemy face the way it walks
    //#/ It is also called every frame for flying enemies 
    //// 
    private void LookAtPlayer(){
        Vector3 direction = _player.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _lookSpeed * Time.deltaTime);
    }

    ////
    //#/ LookAwayFromPlayer is called for the ranged enemy when the player is too close.
    //// 
    private void LookAwayFromPlayer(){
        Vector3 awayDirection = _player.transform.position + transform.position;
        awayDirection.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(awayDirection), _lookSpeed * Time.deltaTime);
    }

    ////
    //#/ MeleeAttack deals damage to the player. Still needs a PhysicsOverlap bool so that
    //#/ it does not do damage to the player if they can escape in time.
    //// 
    IEnumerator MeleeAttack(){
        _delay = true;
        charstat.TakeDmg(10);
        yield return new WaitForSeconds(2f);
        _delay = false;
    }

    ////
    //#/ TankAttack deals damage to the player. Still needs a PhysicsOverlap bool so that
    //#/ it does not do damage to the player if they can escape in time.
    //// 
    IEnumerator TankAttack(){
        _delay = true;
        charstat.TakeDmg(20);
        yield return new WaitForSeconds(2f);
        _delay = false;
    }

    ////
    //#/ RangedAttack instantiates a projectile randomly at the ranged enemies position.
    //#/ It rotates the projectile in the direction of the player, while the projectile itself
    //#/ controls its own veloctity. It uses delay to prevent repeated calling.
    //// 
    IEnumerator RangedAttack(){
        _delay = true;
        yield return new WaitForSeconds(Random.Range(0.5f,2f));
        if(_enemyDead == false){
            if(_projectilePrefab != null){ //check if the prefab is assigned so no errors are returned
                Instantiate(_projectilePrefab,_shotpoint.transform.position,transform.rotation);
            }
            yield return new WaitForSeconds(Random.Range(3f,6f));
            _delay = false;
        }
    }

    ////
    //#/ FlyingAttack instantiates a projectile randomly with gravity using an assigned prefab.
    //#/ The prefav handles its own trajectory.
    //// 
    IEnumerator FlyingAttack(){
        _delay = true;
        yield return new WaitForSeconds(Random.Range(4f,6f));
        if(_enemyDead == false){
            if(_projectileGravityPrefab != null){ //check if the prefab is assigned so no errors are returned
                Instantiate(_projectileGravityPrefab,_shotpoint.transform.position,Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(3f,5f));
            _delay = false;
        }
    }
}