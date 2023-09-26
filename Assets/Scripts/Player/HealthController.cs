using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int Health;
    public int Shield;
    public int MaxHealth;
    public int MaxShield;

    private void Start()
    {
        Health = MaxHealth;
        Shield = MaxShield;
    }

    public void GetDamage(int damage)
    {
        if (damage <= 0)
            return;

        if (damage <= Shield)
        {
            Shield -= damage;
            return;
        }
        else
        {
            damage -= Shield;
            Shield = 0;
        }


        Health -= damage;

        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
