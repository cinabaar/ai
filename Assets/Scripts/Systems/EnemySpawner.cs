using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    private Transform _playerTransform;
    private BoundingBoxComponent _boundingBox;

    public void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
        _boundingBox = GetComponent<BoundingBoxComponent>();
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (transform.childCount < 5 && _playerTransform)
            {
                var prefab = EnemyPrefabs.RandomElement();
                var position = (_boundingBox.Box.RandomPointInBox()).SetY(prefab.transform.position.y);
                var rotation = Quaternion.LookRotation(_playerTransform.position - position);
                Instantiate(prefab, position, rotation, transform);
            }
            yield return new WaitForSeconds(3);
        }
    }
}
