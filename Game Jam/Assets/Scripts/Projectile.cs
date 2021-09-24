using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _projectileSpeed;
    [SerializeField] GameObject _particleCollide;
    void Start(){
        Destroy(this.gameObject, 15f);
    }
    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(Vector3.forward*_projectileSpeed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
        Instantiate(_particleCollide,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
