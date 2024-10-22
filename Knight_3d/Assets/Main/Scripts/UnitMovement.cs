using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    public float detectionRange = 10f;  // ������ ����������� ������
    public float moveSpeed = 3f;        // �������� ��������
    public bool isAlly;                 // ����������, ������� �� ���

    private GameObject currentTarget;   // ������� ����
    private NavMeshAgent navMeshAgent;  // ��������� NavMeshAgent ��� ������������

    private void Start()
    {
        // �������� ��������� NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent �� ������ �� ������� " + gameObject.name);
        }
    }

    private void Update()
    {
        if (navMeshAgent == null || !navMeshAgent.isOnNavMesh)
        {
            // ���� NavMeshAgent ����������� ��� �� ��������� �� NavMesh, ������ �� ������
            return;
        }

        FindTarget();

        if (currentTarget != null)
        {
            Health targetHealth = currentTarget.GetComponent<Health>();
            if (targetHealth != null && targetHealth.IsDead())
            {
                currentTarget = null; // ���� ���� ������, ���������� ������� ����
                return;
            }

            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

            if (distance > navMeshAgent.stoppingDistance)
            {
                // ���������, ��� ����� ������� � ����� ���������
                if (!navMeshAgent.isStopped)
                {
                    navMeshAgent.SetDestination(currentTarget.transform.position);
                }
            }
            else
            {
                // ���������������, ����� �������� ����
                navMeshAgent.isStopped = true;
            }
        }
    }

    private void FindTarget()
    {
        // ����������, ����� ��� ������: ������ ��� ��������� � ��������� ��� ������
        string targetTag = isAlly ? "Enemy" : "Ally";
        GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag(targetTag);
        float closestDistance = detectionRange;
        GameObject closestTarget = null;

        foreach (GameObject target in potentialTargets)
        {
            Health targetHealth = target.GetComponent<Health>();
            if (targetHealth != null && targetHealth.IsDead())
            {
                continue; // ���������� ������� �����
            }

            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
            }
        }

        currentTarget = closestTarget; // ��������� ��������� ����
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
