using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _speed;
    [SerializeField] GameObject _particles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,_speed*Time.deltaTime,0));
    }
    
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            //Instantiate(_particles,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
