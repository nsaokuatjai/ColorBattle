using UnityEngine;
using System;
using System.Collections.Generic;

public class Enemy
{
    public string Name { get; private set; }

    public Enemy(string name)
    {
        Name = name;
    }
}

public class EnemySpawner : MonoBehaviour
{
    private System.Random random = new System.Random();

    public GameObject enemyPrefab;

    private void Start()
    {
        int maxEnemiesPerFloor = 1;

        List<int> allFloors = new List<int>();
        for (int i = 1; i <= 14; i++)
        {
            allFloors.Add(i);
        }

        List<int> weakFloors = GetRandomElements(allFloors.GetRange(0, 6), 3);
        List<int> midFloors = GetRandomElements(allFloors.GetRange(7, 5), 3);
        List<int> strongFloors = GetRandomElements(allFloors.GetRange(12, 2), 1);
        List<int> gameSequence = new List<int>();
        gameSequence.AddRange(weakFloors);
        gameSequence.Add(7); // Mid boss
        gameSequence.AddRange(midFloors);
        gameSequence.AddRange(strongFloors);

        foreach (int floor in gameSequence)
        {
            Enemy[] enemies = SummonEnemy(floor);
            Debug.Log($"Floor {floor}: {string.Join(", ", Array.ConvertAll(enemies, enemy => enemy.Name))}");

            // 敵をスポーンする（プレイヤーの視界外に生成）
            foreach (Enemy enemy in enemies)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    private Enemy[] SummonEnemy(int floorNumber)
    {
        List<Enemy> weakEnemies = new List<Enemy>
        {
            new Enemy("Weak Enemy 1"),
            new Enemy("Weak Enemy 2"),
            new Enemy("Weak Enemy 3"),
            new Enemy("Weak Enemy 4"),
            new Enemy("Weak Enemy 5"),
            new Enemy("Weak Enemy 6")
        };

        Enemy midBoss = new Enemy("Mid Boss");

        List<Enemy> midEnemies = new List<Enemy>
        {
            new Enemy("Mid Enemy 1"),
            new Enemy("Mid Enemy 2"),
            new Enemy("Mid Enemy 3"),
            new Enemy("Mid Enemy 4"),
            new Enemy("Mid Enemy 5")
        };

        List<Enemy> strongEnemies = new List<Enemy>
        {
            new Enemy("Strong Enemy 1"),
            new Enemy("Strong Enemy 2")
        };

        if (floorNumber >= 1 && floorNumber <= 6)
        {
            return new Enemy[] { weakEnemies[floorNumber - 1] };
        }
        else if (floorNumber == 7)
        {
            return new Enemy[] { midBoss };
        }
        else if (floorNumber >= 8 && floorNumber <= 12)
        {
            return new Enemy[] { midEnemies[floorNumber - 8] };
        }
        else if (floorNumber >= 13 && floorNumber <= 14)
        {
            return new Enemy[] { strongEnemies[floorNumber - 13] };
        }
        else
        {
            throw new ArgumentException("Invalid floor number");
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // プレイヤーの視界外にランダムなスポーン位置を生成
        // ここでは、単純にプレイヤーから一定距離離れた位置に生成する例を示します
        Vector3 playerPosition = Camera.main.transform.position;
        float spawnDistance = 10f;
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere.normalized;
        return playerPosition + randomDirection * spawnDistance;
    }

    private List<T> GetRandomElements<T>(List<T> list, int count)
    {
        List<T> result = new List<T>();
        HashSet<int> selectedIndices = new HashSet<int>();

        while (result.Count < count)
        {
            int index = random.Next(list.Count);
            if (!selectedIndices.Contains(index))
            {
                selectedIndices.Add(index);
                result.Add(list[index]);
            }
        }

        return result;
    }
}
