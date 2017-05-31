using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _initialSpeed;

    private Vector3 _startingLocation;

	void Start ()
    {
        _startingLocation = transform.position;
        GetComponent<Rigidbody>().AddForce(transform.forward * _initialSpeed, ForceMode.Impulse);
	}

    void Update()
    {
        if((transform.position - _startingLocation).magnitude > _maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
