using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public GameObject healthBarUI;
    public Slider slider;
    public GameObject enemy;
    CharStat enemyStats;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyStats = enemy.GetComponent<CharStat>();
        slider.value = enemyStats.currHP;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemyStats.currHP;

        if(enemyStats.currHP == 0) return;

        if(enemyStats.currHP < enemyStats.maxHP) healthBarUI.SetActive(true);
    }
}
