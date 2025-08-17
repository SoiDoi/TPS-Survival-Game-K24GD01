using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab; // Prefab của enemy / Enemy prefab
    [SerializeField] private Transform _transform; // Transform để spawn enemy / Transform to spawn enemies at
    [SerializeField] private GameObject _EnemyParent; // objett cha của enemy / Parent object for the enemies

    [SerializeField] private int _currentWave = 0; // Số lượng enemy spawn mỗi lần / Number of enemies to spawn each round
    [SerializeField] private float timeBetweenWaves = 5f; // Thời gian giữa các wave / Time between waves
    [SerializeField] private int baseEnemyCount = 5; // Số lượng enemy cơ bản mỗi wave / Base number of enemies per wave

    [SerializeField] private int _aliveEnemies => _EnemyParent.transform.childCount; // Số lượng enemy còn sống / Number of alive enemies
    private void Start()
    {
        if (_enemyPrefab == null || _enemyPrefab.Length == 0)
        {
            Debug.LogError("Enemy prefabs are not assigned!");
            return;
        }
        if (_transform == null)
        {
            Debug.LogError("Transform for spawning enemies is not assigned!");
            return;
        }
        if (_EnemyParent == null)
        {
            Debug.LogError("Enemy parent object is not assigned!");
            return;
        }
        StartCoroutine(SpawnNextWave());
    }

    private IEnumerator SpawnNextWave()
    {
        _currentWave++;
        GameManager.Instance.NextWave(); // Gọi hàm NextWave trong GameManager để cập nhật wave / Call NextWave function in GameManager to update the wave
        Debug.Log($"Wave {_currentWave} bắt đầu!");
        // Tăng số lượng enemy theo wave
        int enemyCount = baseEnemyCount + _currentWave * 2;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f); // delay giữa các enemy
        }

        yield return new WaitUntil(() => _aliveEnemies <= 0);
        StartCoroutine(WaitAndSpawnNext());
    }

    private void SpawnEnemy()
    {
        int index = 0; // Chọn ngẫu nhiên một prefab enemy / Randomly select an enemy prefab
        if (_enemyPrefab.Length > (_currentWave/5))
        {
            index = _currentWave / 5; // Lấy chỉ số prefab dựa trên wave hiện tại / Get the prefab index based on the current wave
        }
        else
        {
            index = UnityEngine.Random.Range(0, _enemyPrefab.Length); // Nếu không đủ prefab, chọn ngẫu nhiên / If not enough prefabs, randomly select one
        }

        var Enemy = Instantiate(_enemyPrefab[index], _transform.position, Quaternion.identity);
        Enemy.transform.SetParent(_EnemyParent.transform); // Đặt enemy vào object cha / Set the enemy as a child of the parent object
    }



    private IEnumerator WaitAndSpawnNext()
    {
        Debug.Log($" Wave {_currentWave} đã xong, chuẩn bị wave mới...");
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnNextWave());
    }
}
