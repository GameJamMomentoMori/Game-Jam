using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBallProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _particleCollide;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        if(other.tag != "Enemy"){
            Instantiate(_particleCollide,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
