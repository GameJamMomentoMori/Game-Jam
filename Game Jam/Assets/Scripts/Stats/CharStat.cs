using UnityEngine;

public class CharStat : MonoBehaviour
{
    public int maxHP = 100;
    public int currHP {get; private set;}
    public int maxSP = 25; //for magic consumption
    public Stat dmg;
    public Stat armor;
    public HUDHealth HPBar;
    public Animator _blood;
    public bool isPlayer;
    public AudioSource damageSound;
    void Start()
    {
        //HPBar = GameObject.Find("HealthBar");
        //HPBar.SetMaxHealth(maxHP);
        _blood = GameObject.Find("Blood").GetComponent<Animator>();
    }

    void Awake()
    {
        currHP = maxHP;
    }

    public void TakeDmg(int dmg) {
        dmg -= armor.getVal();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue);
        currHP -= dmg;
        if(isPlayer){
            BloodAnimation();
            damageSound.Play();
        }
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

     public void BloodAnimation(){
        _blood.Play("Blood");
    }

    public void heal() {
        currHP = 100;
        Debug.Log("Player healed. HP at " + currHP);
    }

}
