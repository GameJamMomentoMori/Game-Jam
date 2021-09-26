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
    GameObject _player;
    CharStat charstat;
    
    void Awake(){
        _player = GameObject.Find("FirstPersonPlayer");
        charstat = _player.GetComponent<CharStat>();
        _firepointTransform = GameObject.Find("PlayerFirePoint").GetComponent<Transform>();
    }

    void Start(){
        Destroy(this.gameObject, 15f);
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
         if(other.tag != "Player"){
            if(other.tag == "Enemy"){
                //charstat.TakeDmg(5);
                //CameraShaker.Instance.ShakeOnce(8, 3, 0.2f, 0.5f);
            }
            Instantiate(_particleCollide,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Fire(){
        yield return new WaitForSeconds(0.8f);
        _fire = true;
    }
}
