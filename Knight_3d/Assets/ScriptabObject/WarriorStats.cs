using UnityEngine;

[CreateAssetMenu(fileName = "NewWarriorStats", menuName = "Warrior/Stats")]
public class WarriorStats : ScriptableObject
{
    public string warriorName;       // Имя воина
    public float maxHealth;          // Максимальное здоровье
    public float attackPower;        // Сила атаки
    public float defense;            // Защита
}