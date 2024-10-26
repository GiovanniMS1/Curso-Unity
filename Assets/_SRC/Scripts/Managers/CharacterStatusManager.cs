using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStatusManager : MonoBehaviour, IDamageable
{
    public Status status;

    public event Action OnTakeDamage;

    public void InitStatus(Status pStatus)
    {
        status.Health = pStatus.Health;
        status.Armor = pStatus.Armor;
        status.MagicResist = pStatus.MagicResist;

    }

    public void TakeDamage(int amount)
    {
        Debug.Log("TOMANDO " + amount + " DE DANO");

        status.Health -= amount;

        OnTakeDamage?.Invoke();

        // Eventos ao tomar dano
        // Saia sangue
        // animacao tomar dano
        // boneco piscando
        //

        if (status.Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
