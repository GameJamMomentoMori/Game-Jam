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
    [SerializeField] bool _delay2 = false;
    public DialogManager dialog;
    public Interactable focus;
    CharStat myStats;
    [SerializeField] EnemyHealthController enemyStats;
    [SerializeField] CharacterCombat charAtk;
    
    public AudioSource slash;
    public AudioSource fire;
    public AudioSource woosh; 
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
            if(!dialog.dialogDone) {
                return;
            }
            _playerRightAnimator.Play("Attack");
            if(!_delay2)
                StartCoroutine(SoundDelay());
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 1000, new Color(1f,0.922f,0.016f,1f));

            if(Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null) {
                    if(interactable.hasInteracted== false){
                        interactable.Interact();
                        if (interactable.distance <= interactable.radius) {
                            slash.Play();
                        }
                    }
                }
            }
        }

        // if we right click
        if(Input.GetMouseButtonDown(1)) {
            if(!dialog.dialogDone) {
                return;
            }
            if(!_delay){
                _playerLeftAnimator.Play("Magic Attack");
                StartCoroutine(Projectile());
            }
        }
    }

    IEnumerator Projectile(){
        _delay = true;
        //yield return new WaitForSeconds(0.5f);
        fire.Play();
        Instantiate(_playerProjectile,_firepointTransform.position,_firepointTransform.rotation);
        yield return new WaitForSeconds(1.2f);
        _delay = false;
    }

    IEnumerator SoundDelay(){
        _delay2 = true;
        woosh.Play();
        yield return new WaitForSeconds(0.7435898f);
        _delay2 = false;
    }
}