using UnityEngine;

public class ShieldContactDamage : MonoBehaviour
{
    public GameObject Instigator;

    private void OnTriggerEnter(Collider other)
    {
        var takeDamage = other.transform.GetComponent<ITakeDamage>();
        if (takeDamage != null)
        {
            takeDamage.ApplyDamage(new Damage { Amount = 1, Instigator = Instigator, Direction = Instigator.transform.forward });
        }
    }
}
