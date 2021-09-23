using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    [Header("Customizable")]
    [SerializeField] float _lookSpeed = 5f;
    [SerializeField] float _distance;
    
    [Header("State")]
    [SerializeField] bool _enemyDead;

    [Header("Navigation")]
    GameObject _player;
    public NavMeshAgent agent;
    
    [Header("Ranged")]
    [SerializeField] bool _delay;
    [SerializeField] GameObject _projectilePrefab;

     public enum Enemy {Melee,Ranged,Tank,Flying};
     public Enemy currentEnemy;

    void Awake()
    {
        _player = GameObject.Find("FirstPersonPlayer");
    }

    void Start(){
        //currentEnemy = Enemy.Melee;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer(currentEnemy);
        
         if(currentEnemy == Enemy.Ranged){
            RunFromPlayer();
        }
    }

    ////
    private void FollowPlayer(Enemy enemy){
        _distance = Vector3.Distance(_player.transform.position, this.transform.position);
        
        //if enemy type is melee, enemy is not dead, and 
        //distance is less than two meters, stop and attack
        if(enemy == Enemy.Melee){
            if(_distance < 2f || _enemyDead){
                agent.isStopped = true;
                if(!_enemyDead ){
                    MeleeAttack();
                }
            }
            //if enemy is not within 2 meters, navigate towards player
            else{
                agent.isStopped = false;
                agent.SetDestination(_player.transform.position);
            
            }
        }

        //if enemy type is ranged, enemy is alive and distance 
        //is greater than 14m, navigate towards the player 
        if(enemy == Enemy.Ranged){
            if(_distance > 14f && !_enemyDead){
                agent.isStopped = false;
                agent.SetDestination(_player.transform.position);
            }
        }
    }

    private void RunFromPlayer(){
        //if enemy alive and distance between 9-14m, stop and shoot
        if((_distance >= 9f && _distance <= 14f) && !_enemyDead){
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
        //if enemy is less than 9 meters, run away from player
        else if(_distance < 9f ){
            agent.isStopped = false;
            
            Vector3 directionToPlayer = transform.position - _player.transform.position;
            Vector3 runAwayPos = transform.position + directionToPlayer;
            agent.SetDestination(runAwayPos);
            //LookAwayFromPlayer();
            
        }
    }

    private void LookAtPlayer(){
        Vector3 direction = _player.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _lookSpeed * Time.deltaTime);
    }
    
    private void LookAwayFromPlayer(){
        Vector3 awayDirection = _player.transform.position + transform.position;
        awayDirection.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(awayDirection), _lookSpeed * Time.deltaTime);
    }

    private void MeleeAttack(){
        //PlayerHealthController.DamagePlayer(10f);
    }

//profesor johnson is it better to have this take a 
//gameobect "projectile" and instantiate the parameter? or better to just use the 
//gameobject projectile prefab the script takes initially 
    private IEnumerator RangedAttack(){
        _delay = true;
        yield return new WaitForSeconds(0.5f);
        if(_enemyDead == false){
            if(_projectilePrefab != null){
                Instantiate(_projectilePrefab,transform.position,transform.rotation);
            }
            yield return new WaitForSeconds(2f);
            _delay = false;
        }
    }
}
