using System;
using System.Collections;
using UnityEngine;

public class EnemyFireAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform _bulletSpawnTransform;
    [SerializeField]
    private int _bulletCount;
    [SerializeField]
    private float _delayBetweenBullets;

    private GameObject _bulletParent;
    private bool _firing;

    private void Awake()
    {
        _bulletParent = GameObject.Find("EnemyBulletParent");
        if(!_bulletParent)
        {
            _bulletParent = new GameObject("EnemyBulletParent");
        }
    }

    public IEnumerator ShootBullets()
    {
        for(int i=0;i<_bulletCount;i++)
        {
            var bullet = Instantiate(_bulletPrefab, _bulletSpawnTransform.position, _bulletSpawnTransform.rotation, _bulletParent.transform);
            bullet.GetComponent<ProjectileDamage>().Instigator = gameObject;
            yield return new WaitForSeconds(_delayBetweenBullets);
        }
    }
}
