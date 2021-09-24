using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currHP { get; private set; }
    public Stat dmg;
    public Stat res;
    public Stat armor;

    public HUDHealth healthBar;

    void Start()
    {
        // Set healthbar max to the max hp
        healthBar.SetMaxHealth(maxHP);
    }

    void Awake()
    {
        currHP = maxHP;
    }

    void Update()
    {
        // Can remove these eventually - just used for debugging for now
        if (Input.GetKeyDown(KeyCode.T)) damage(10);
        if (Input.GetKeyDown(KeyCode.R)) heal(10);
        if (Input.GetKeyDown(KeyCode.E)) Debug.Log(transform.name + " has " + getHealth() + " health");


    }

    // Damages the player 
    // To have enemy damage player, invoke PlayerHealth.damage(x), where x is amount damaged
    public void damage(int dmg)
    {
        //dmg -= armor.getVal();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue);
        currHP -= dmg;

        Debug.Log(transform.name + " takes " + dmg + " damage");

        // Update health bar
        healthBar.SetHealth(currHP);

        // Check if player was killed
        if (currHP <= 0)
        {
            Die();
        }
    }

    // Heals the player 
    // To heal player, invoke PlayerHealth.heal(x), where x is amount restored
    public void heal(int res)
    {
        currHP += res;

        // Prevents healing past max health
        if(currHP > maxHP)
        {
            currHP = maxHP;
        }

        // Update health bar
        healthBar.SetHealth(currHP);

        Debug.Log(transform.name + " heals " + res + " health");
    }

    // Gets the current player health (mainly used for UI)
    public int getHealth()
    {
        return currHP;
    }

    public virtual void Die()
    {
        //Die in some way
        //This method is meant to be overwritten
        Debug.Log(transform.name + " died");
    }
}
