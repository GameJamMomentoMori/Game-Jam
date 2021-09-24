using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArch : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
         Vector3 playerPos = new Vector3(_player.position.x, _player.position.y, _player.position.z);
 
        // Aim bullet in player's direction.
        transform.rotation = Quaternion.LookRotation(playerPos);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    
    }
}
