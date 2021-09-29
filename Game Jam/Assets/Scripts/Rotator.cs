using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _speed;
    [SerializeField] GameObject _particles;
    PlayerStats playerStats;

    void Awake()
    {   
        GameObject playerObj = GameObject.Find("FirstPersonPlayer");
        playerStats = playerObj.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,_speed*Time.deltaTime,0));
    }
    
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Instantiate(_particles,new Vector3(transform.position.x,transform.position.y+1,transform.position.z),Quaternion.identity);
            Debug.Log("Picking up " + gameObject.name);            
            playerStats.heal();

            Destroy(this.gameObject);
        }
    }
}
