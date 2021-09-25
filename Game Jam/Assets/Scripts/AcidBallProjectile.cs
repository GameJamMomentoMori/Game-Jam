using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class AcidBallProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _particleCollide;

    GameObject _player;
    CharStat charstat;
    
    void Awake(){
        _player = GameObject.Find("FirstPersonPlayer");
        charstat = _player.GetComponent<CharStat>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        if(other.tag != "Enemy"){
            if(other.tag == "Player"){
                charstat.TakeDmg(5);
                CameraShaker.Instance.ShakeOnce(8, 3, 0.2f, 0.5f);
            }
            Instantiate(_particleCollide,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
