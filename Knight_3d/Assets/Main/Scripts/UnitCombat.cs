using UnityEngine;
using UnityEngine.AI;

public class UnitCombat : MonoBehaviour
{
    public float attackRange = 1.5f;    // ������ �����
    public float attackDamage = 10f;    // ���� ��� �����
    public float attackCooldown = 1f;   // �������� ����� �������

    private float lastAttackTime;       // ����� ��������� �����
    private UnitMovement unitMovement;  // ������ �� ������ �������� ��� ��������� ����
    private Animator animator;          // ��������� Animator ��� ���������� ����������
    private Health health;              // ��������� Health ��� �������� ��������� ��������

    private void Start()
    {
        // �������� ��������� UnitMovement
        unitMovement = GetComponent<UnitMovement>();

        if (unitMovement == null)
        {
            Debug.LogError("UnitMovement �� ������ �� ������� " + gameObject.name);
        }

        // �������� ��������� Animator
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator �� ������ �� ������� " + gameObject.name);
        }

        // �������� ��������� Health
        health = GetComponent<Health>();
        if (health == null)
        {
            Debug.LogError("Health �� ������ �� ������� " + gameObject.name);
        }
        else
        {
            health.OnDeath += HandleDeath; // ������������� �� ������� ������
        }
    }

    private void Update()
    {
        if (health != null && health.IsDead())
        {
            return; // ���� �������� �����, �� ��������� ���������� ��������
        }

        GameObject currentTarget = unitMovement.GetCurrentTarget();

        // ��������� ��������� ��������
        if (animator != null)
        {
            animator.SetBool("isMoving", unitMovement.IsMoving());
        }

        if (currentTarget != null)
        {
            Health targetHealth = currentTarget.GetComponent<Health>();
            if (targetHealth != null && targetHealth.IsDead())
            {
                return; // ���� ���� ������, �� ������� �
            }

            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

            if (distance <= attackRange)
            {
                // �������, ���� � ������� ����� � ������ ���������� ������� � ������� ��������� �����
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    Attack(currentTarget);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    private void Attack(GameObject target)
    {
        if (animator != null)
        {
            animator.SetTrigger("isAttacking"); // ��������� �������� �����
        }

        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null && !targetHealth.IsDead())
        {
            targetHealth.TakeDamage(attackDamage);
            Debug.Log(gameObject.name + " �������� " + target.name + " �� " + attackDamage + " �����");
        }
    }

    public bool IsAttacking()
    {
        return unitMovement.GetCurrentTarget() != null && Vector3.Distance(transform.position, unitMovement.GetCurrentTarget().transform.position) <= attackRange;
    }

    private void HandleDeath()
    {
        if (animator != null)
        {
            animator.SetTrigger("isDead"); // ��������� �������� ������
        }

        // ��������� NavMeshAgent � ������ ��������, ���� �������� �����
        if (unitMovement != null)
        {
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            if (navMeshAgent != null && navMeshAgent.isOnNavMesh)
            {
                navMeshAgent.isStopped = true;
                navMeshAgent.enabled = false; // ��������� �����, ����� ������������� ��������
            }
        }

        // ��������� ���������, ���� �� ����������
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // ������� ������ ����� ��������� ��������
        Destroy(gameObject, 3f);
    }
}