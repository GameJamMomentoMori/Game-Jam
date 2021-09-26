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
    EnemyHealthController enemyStats;

    void Start() {
        cam = Camera.main;
        myStats = GetComponent<CharStat>();
    }

    // Update is called once per frame
    void Update()
    {
        // if we left click
        if(Input.GetMouseButtonDown(0)) {
            _playerRightAnimator.Play("Attack");
            //ian work in progress rn it work fine tho
            //if player presses mouse button again within timeframe of first animation,
            //play second attack animation
            //else play first then go back to idle
            //_playerRightAnimator.SetInteger("attackindex",1);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null) {
                    
                    //SetFocus(interactable);
                    //Debug.Log(transform.name + " hit");
                }
                //enemyStats.TakeDmg(myStats.dmg.getVal());                
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

    void SetFocus(Interactable newFocus) {
        focus = newFocus;
    }
}
