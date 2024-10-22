using UnityEngine;

[CreateAssetMenu(fileName = "NewWarriorStats", menuName = "Warrior/Stats")]
public class WarriorStats : ScriptableObject
{
    public string warriorName;       // ��� �����
    public float maxHealth;          // ������������ ��������
    public float attackPower;        // ���� �����
    public float defense;            // ������
}