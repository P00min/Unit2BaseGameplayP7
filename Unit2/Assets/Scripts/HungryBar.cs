using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryBar : MonoBehaviour
{
    [Min(1)] public int maxValue;
    public int value { get; private set; }

    void Start()
    {
        value = maxValue;
    }

    /// <summary>
    /// Takes damage from health
    /// </summary>
    /// <param name="damage">amount to take from health</param>
    /// <returns>Whether target is dead or not</returns>
    public bool TakeDamage(int damage)
    {
        if (value <= damage)
        {
            value = 0;
            return true;
        }
        value -= damage;
        return false;
    }
}


