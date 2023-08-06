using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private Pipe _pipe;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private bool _isSpawning = true;

    private void Start()
    {
        Initialize(_pipe.gameObject);
        StartCoroutine(SpawnPipes());
    }

    public void SetNewPipe(Pipe pipe)
    {
        ClearPool();
        _pipe = pipe;
        Initialize(_pipe.gameObject);
    }

    private IEnumerator SpawnPipes()
    {
        WaitForSeconds delay = new(_secondsBetweenSpawn);

        while (_isSpawning)
        {
            if (TryGetObject(out GameObject pipe))
            {
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector2 spawnPoint = new(transform.position.x, spawnPositionY);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;
                DisableObjectAbroadScreen();
                yield return delay;
            }
        }
    }
}
