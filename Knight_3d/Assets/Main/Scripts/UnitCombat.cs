using UnityEngine;
using UnityEngine.AI;

public class UnitCombat : MonoBehaviour
{
    public float attackRange = 1.5f;    // Радиус атаки
    public float attackDamage = 10f;    // Урон при атаке
    public float attackCooldown = 1f;   // Задержка между атаками

    private float lastAttackTime;       // Время последней атаки
    private UnitMovement unitMovement;  // Ссылка на скрипт движения для получения цели
    private Animator animator;          // Компонент Animator для управления анимациями
    private Health health;              // Компонент Health для проверки состояния здоровья

    private void Start()
    {
        // Получаем компонент UnitMovement
        unitMovement = GetComponent<UnitMovement>();

        if (unitMovement == null)
        {
            Debug.LogError("UnitMovement не найден на объекте " + gameObject.name);
        }

        // Получаем компонент Animator
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator не найден на объекте " + gameObject.name);
        }

        // Получаем компонент Health
        health = GetComponent<Health>();
        if (health == null)
        {
            Debug.LogError("Health не найден на объекте " + gameObject.name);
        }
        else
        {
            health.OnDeath += HandleDeath; // Подписываемся на событие смерти
        }
    }

    private void Update()
    {
        if (health != null && health.IsDead())
        {
            return; // Если персонаж мертв, не выполняем дальнейшие действия
        }

        GameObject currentTarget = unitMovement.GetCurrentTarget();

        // Управляем анимацией движения
        if (animator != null)
        {
            animator.SetBool("isMoving", unitMovement.IsMoving());
        }

        if (currentTarget != null)
        {
            Health targetHealth = currentTarget.GetComponent<Health>();
            if (targetHealth != null && targetHealth.IsDead())
            {
                return; // Если цель мертва, не атакуем её
            }

            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

            if (distance <= attackRange)
            {
                // Атакуем, если в радиусе атаки и прошло достаточно времени с момента последней атаки
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
            animator.SetTrigger("isAttacking"); // Запускаем анимацию атаки
        }

        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null && !targetHealth.IsDead())
        {
            targetHealth.TakeDamage(attackDamage);
            Debug.Log(gameObject.name + " атаковал " + target.name + " на " + attackDamage + " урона");
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
            animator.SetTrigger("isDead"); // Запускаем анимацию смерти
        }

        // Отключаем NavMeshAgent и другие действия, если персонаж мертв
        if (unitMovement != null)
        {
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            if (navMeshAgent != null && navMeshAgent.isOnNavMesh)
            {
                navMeshAgent.isStopped = true;
                navMeshAgent.enabled = false; // Отключаем агент, чтобы предотвратить движение
            }
        }

        // Отключаем коллайдер, если он существует
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Удаляем объект после небольшой задержки
        Destroy(gameObject, 3f);
    }
}