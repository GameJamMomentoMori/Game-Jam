using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class PlayerProjectile : MonoBehaviour
{
    Camera cam;
    [SerializeField] float _projectileSpeed;
    [SerializeField] GameObject _particleCollide;
    [SerializeField] bool _fire;
    [SerializeField] Transform _firepointTransform;
    [SerializeField] GameObject _growParticle;
    Ray ray;
    GameObject _player;
    GameObject enemy;
    CharStat charstat, enemyStats;
    CharacterCombat charAtk;
    public AudioSource explosion;

    EnemyAIController enemyAI;
    
    void Awake(){
        cam = Camera.main;
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
        //Debug.DrawRay(ray.origin, ray.direction * 1000, new Color(1f,0.922f,0.016f,1f));

        if(_fire)
        transform.Translate(Vector3.forward*_projectileSpeed*Time.deltaTime);

        else{
            transform.position = _firepointTransform.position;
            transform.rotation = _firepointTransform.rotation;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){
           // other.GetComponent<whatever>
            //enemyStats = enemy.GetComponent<CharStat>();
            //do enemy damage here
            //charAtk.Attack(enemyStats);
            Interactable interactable = other.GetComponent<Collider>().GetComponent<Interactable>();
            if(interactable != null) {
                    if(interactable.hasInteracted== false) {
                        interactable.isRanged = true;
                        interactable.Interact();
                    }
            }
            //other.GetComponent<EnemyHealthController>().TakeDamage();
            //enemyAI = other.GetComponent<EnemyAIController>();
            
        }
        Instantiate(_particleCollide,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
        //StartCoroutine(enemyAI.TakeDamage());
        //enemyAI.enemyDamaged();
    }

    IEnumerator Fire(){
        yield return new WaitForSeconds(0.8f);
        _fire = true;
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        ray = cam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100)) {
            transform.LookAt(hit.point);
        }
    }
}
