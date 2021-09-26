using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float _projectileSpeed;
    [SerializeField] GameObject _particleCollide;
    [SerializeField] bool _fire;
    [SerializeField] Transform _firepointTransform;
    [SerializeField] GameObject _growParticle;
    GameObject _player;
    GameObject enemy;
    CharStat charstat, enemyStats;
    CharacterCombat charAtk;
    
    void Awake(){
        _player = GameObject.Find("FirstPersonPlayer");
        charstat = _player.GetComponent<CharStat>();
        _firepointTransform = GameObject.Find("PlayerFirePoint").GetComponent<Transform>();
    }

    void Start(){
        Destroy(this.gameObject, 15f);
        //Instantiate(_growParticle,transform.position,Quaternion.identity);
        StartCoroutine(Fire());
    }
    // Start is called before the first frame update
    void Update()
    {
        if(_fire)
        transform.Translate(Vector3.forward*_projectileSpeed*Time.deltaTime);
        else{
            transform.position = _firepointTransform.position;
            transform.rotation = _firepointTransform.rotation;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){
            //other.GetComponent<whatever>
            enemyStats = enemy.GetComponent<CharStat>();
            //do enemy damage here
            charAtk.Attack(enemyStats);
        }
        Instantiate(_particleCollide,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
        
    }

    IEnumerator Fire(){
        yield return new WaitForSeconds(0.8f);
        _fire = true;
    }
}
