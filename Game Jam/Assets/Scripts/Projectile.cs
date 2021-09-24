using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _projectileSpeed;
    [SerializeField] GameObject _particleCollide;
    GameObject _player;
    CharStat charstat;
    
    void Awake(){
        _player = GameObject.Find("FirstPersonPlayer");
        charstat = _player.GetComponent<CharStat>();
    }

    void Start(){
        Destroy(this.gameObject, 15f);
    }
    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(Vector3.forward*_projectileSpeed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
         if(other.tag != "Enemy"){
            if(other.tag == "Player"){
                charstat.TakeDmg(5);
            }
            Instantiate(_particleCollide,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
