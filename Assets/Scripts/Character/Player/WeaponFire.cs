using System.Collections;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private Transform _bulletSpawnTransform;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private string _parentGameobjectName = "BulletParent";

    private GameObject _bulletParent;

    private bool _firing;

    void Awake()
    {
        _bulletParent = GameObject.Find(_parentGameobjectName);
        if (_bulletParent) return;
        _bulletParent = new GameObject(_parentGameobjectName);
    }

    void Update ()
    {
        if(Input.GetAxisRaw("Fire") >= 0.8)
        {
            Fire();
        }
        else if (Input.GetButton("Fire"))
        {
            Fire();
        }
	}

    private void Fire()
    {
        if(!_firing)
        {
            StartCoroutine(FireCoroutine());
        }
    }

    private IEnumerator FireCoroutine()
    { 
        _firing = true;
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnTransform.position, _bulletSpawnTransform.rotation, _bulletParent.transform);
        bullet.GetComponent<ProjectileDamage>().Instigator = gameObject;
        yield return new WaitForSeconds(0.1f);
        _firing = false;
    }
}
