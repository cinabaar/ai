using System;
using UnityEngine;

public class Character : MonoBehaviour, ITakeDamage, IHaveTeam
{
    public float KillY = -5;

    public float Health;
    public float MaxHealth;

    public Action<GameObject> OnKilled;

    [SerializeField]
    private Team _team;
    public Team Team
    {
        get
        {
            return _team;
        }
        set
        {
            _team = value;
        }
    }

    public void ApplyDamage(Damage damage)
    {
        Health = Mathf.Max(Health - damage.Amount, 0);
        if(Health == 0)
        {
            Kill(damage);
        }
    }

    public virtual void Kill(Damage damage)
    {
        if (OnKilled != null)
        {
            OnKilled(gameObject);
        }
    }

    private void Update()
    {
        if(transform.position.y < KillY)
        {
            Kill(new Damage());
        }
    }

}
