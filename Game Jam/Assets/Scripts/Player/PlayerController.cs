using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharStat))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    [SerializeField] Animator _playerRightAnimator;
    [SerializeField] Animator _playerLeftAnimator;
    [SerializeField] GameObject _playerProjectile;
    [SerializeField] Transform _firepointTransform;
    [SerializeField] bool _delay = false;
    public Interactable focus;
    CharStat myStats;
    [SerializeField] EnemyHealthController enemyStats;
    [SerializeField] CharacterCombat charAtk;
    public AudioSource slash;
    void Start() {
        cam = Camera.main;
        myStats = GetComponent<CharStat>();
        charAtk = this.GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {

        
        // if we left click
        if(Input.GetMouseButtonDown(0)) {
            _playerRightAnimator.Play("Attack");
            Debug.Log(_playerRightAnimator.GetCurrentAnimatorStateInfo(0).length);
            //ian work in progress rn it work fine tho
            //if player presses mouse button again within timeframe of first animation,
            //play second attack animation
            //else play first then go back to idle
            //_playerRightAnimator.SetInteger("attackindex",1);
           
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 1000, new Color(1f,0.922f,0.016f,1f));

            if(Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null) {
                    if(interactable.hasInteracted== false)
                    slash.Play();
                    interactable.Interact();
                }
            }
        }

        // if we right click
        if(Input.GetMouseButtonDown(1)) {
            if(!_delay){
                _playerLeftAnimator.Play("Magic Attack");
                StartCoroutine(Projectile());
            }
        }
    }

    IEnumerator Projectile(){
        _delay = true;
        //yield return new WaitForSeconds(0.5f);
        Instantiate(_playerProjectile,_firepointTransform.position,_firepointTransform.rotation);
        yield return new WaitForSeconds(1.2f);
        _delay = false;
    }
}