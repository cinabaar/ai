using UnityEngine;

public class EnemyGrenadeAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject GrenadePrefab;
    [SerializeField]
    private Transform GrenadeSpawnLocation;

    public bool Attack(GameObject target)
    {
        if (!target)
            return false;

        var distance = (transform.position - target.transform.position).magnitude;
        var grenade = Instantiate(GrenadePrefab, GrenadeSpawnLocation.position, GrenadeSpawnLocation.rotation);
        grenade.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up/2) * distance / 2f, ForceMode.Impulse);
        return true;
    }
}