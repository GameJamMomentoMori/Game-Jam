using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharStat))]
public class CharacterCombat : MonoBehaviour
{
    public float atkSpd = 1f;
    private float atkCooldown = 0f;
    public float atkDelay = .6f;

    public event System.Action OnAtk;
    CharStat myStats;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharStat>();
    }

    void Update(){
        atkCooldown -= Time.deltaTime;
    }

    public void Attack (CharStat targetStats) {
        if(atkCooldown <= 0f) {
            StartCoroutine (DoDmg(targetStats, atkDelay));

            if(OnAtk != null) OnAtk(); 

            atkCooldown = 1f / atkSpd;
        }
    }

    IEnumerator DoDmg (CharStat stats, float delay) {
        yield return new WaitForSeconds(delay);
        stats.TakeDmg(myStats.dmg.getVal());
    }

}
