using UnityEngine;

public class CharStat : MonoBehaviour
{
    public int maxHP = 100;
    public int currHP {get; private set;}
    public int maxSP = 25; //for magic consumption
    public Stat dmg;
    public Stat armor;
    public HUDHealth HPBar;

    void Awake() {
        currHP = maxHP;
        HPBar.SetMaxHealth(maxHP);
    }

    void Update() {
        // if(Input.GetKeyDown(KeyCode.T)){
        //     TakeDmg(10);
        // }
    }

    public void TakeDmg(int dmg) {
        dmg -= armor.getVal();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue);
        currHP -= dmg;
        HPBar.SetHealth(currHP);

        Debug.Log(transform.name + " takes " + dmg + " damage");

        if (currHP <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        //Die in some way
        //This method is meant to be overwritten
        Debug.Log(transform.name + " died");
    }
}
