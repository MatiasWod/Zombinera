using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Actor))]
public class LifeController : MonoBehaviour, IDamagable
{
    #region I_DAMAGABLE_PROPERTIES
    public float CurrentLife => _currentLife;
    [SerializeField] private float _currentLife;

    public float MaxLife => GetComponent<Actor>().Stats.MaxLife;
    #endregion

    #region UNITY_EVENTS
    void Start()
    {
        _currentLife = MaxLife;
    }
    #endregion

    #region I_DAMAGABLE_METHODS
    public void TakeDamage(int damage)
    {
        _currentLife -= damage;
        if (IsDead())
        {
            if (name == "Character")
            {
                GameManager.instance.GameOver();
            }
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (_currentLife + amount >= MaxLife)
        {
            _currentLife = MaxLife;
            return;
        }
        _currentLife += amount;
        return;
    }
    #endregion

    #region PRIVATE_METHODS
    private bool IsDead() => _currentLife <= 0;

    private void Die() 
    {

        Destroy(this.gameObject); 
    }
    #endregion
}
