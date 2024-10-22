// Интерфейс для поиска цели
using UnityEngine;

public interface ITargetFinder
{
    GameObject FindTarget(Transform origin, float detectionRange);
}

// Реализация интерфейса для поиска ближайшего врага
public class ClosestEnemyFinder : ITargetFinder
{
    public GameObject FindTarget(Transform origin, float detectionRange)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(origin.position, enemy.transform.position);
            if (distance < minDistance && distance <= detectionRange)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}