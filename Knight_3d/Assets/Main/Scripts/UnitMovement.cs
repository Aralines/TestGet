using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    public float detectionRange = 10f;  // Радиус обнаружения врагов
    public float moveSpeed = 3f;        // Скорость движения
    public bool isAlly;                 // Определяет, союзник ли это

    private GameObject currentTarget;   // Текущая цель
    private NavMeshAgent navMeshAgent;  // Компонент NavMeshAgent для передвижения

    private void Start()
    {
        // Получаем компонент NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent не найден на объекте " + gameObject.name);
        }
    }

    private void Update()
    {
        if (navMeshAgent == null || !navMeshAgent.isOnNavMesh)
        {
            // Если NavMeshAgent отсутствует или не находится на NavMesh, ничего не делаем
            return;
        }

        FindTarget();

        if (currentTarget != null)
        {
            Health targetHealth = currentTarget.GetComponent<Health>();
            if (targetHealth != null && targetHealth.IsDead())
            {
                currentTarget = null; // Если цель мертва, сбрасываем текущую цель
                return;
            }

            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

            if (distance > navMeshAgent.stoppingDistance)
            {
                // Проверяем, что агент активен и может двигаться
                if (!navMeshAgent.isStopped)
                {
                    navMeshAgent.SetDestination(currentTarget.transform.position);
                }
            }
            else
            {
                // Останавливаемся, когда достигли цели
                navMeshAgent.isStopped = true;
            }
        }
    }

    private void FindTarget()
    {
        // Определяем, какой тег искать: врагов для союзников и союзников для врагов
        string targetTag = isAlly ? "Enemy" : "Ally";
        GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag(targetTag);
        float closestDistance = detectionRange;
        GameObject closestTarget = null;

        foreach (GameObject target in potentialTargets)
        {
            Health targetHealth = target.GetComponent<Health>();
            if (targetHealth != null && targetHealth.IsDead())
            {
                continue; // Пропускаем мертвых целей
            }

            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
            }
        }

        currentTarget = closestTarget; // Сохраняем найденную цель
    }

    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }

    public bool IsMoving()
    {
        return navMeshAgent != null && navMeshAgent.velocity.magnitude > 0.1f;
    }
}
