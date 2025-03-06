using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public class Pokemon
    {
        public string name;
        public int maxHP;
        public int currentHP;
        public int attackDamage;
        public Slider healthBar;

        public Pokemon(string name, int hp, int damage, Slider healthBar)
        {
            this.name = name;
            maxHP = hp;
            currentHP = hp;
            attackDamage = damage;
            this.healthBar = healthBar;
            UpdateHealthBar();
        }

        public void TakeDamage(int damage)
        {
            currentHP -= damage;
            if (currentHP < 0) currentHP = 0;
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            if (healthBar != null)
                healthBar.value = (float)currentHP / maxHP;
        }
    }

    public Slider playerHealthBar;
    public Slider enemyHealthBar;
    public Text battleLog;

    private Pokemon playerPokemon;
    private Pokemon enemyPokemon;

    void Start()
    {
        playerPokemon = new Pokemon("Pikachu", 100, 20, playerHealthBar);
        enemyPokemon = new Pokemon("Charizard", 120, 25, enemyHealthBar);
    }

    public void PlayerAttack()
    {
        enemyPokemon.TakeDamage(playerPokemon.attackDamage);
        battleLog.text = $"{playerPokemon.name} attacked! {enemyPokemon.name} has {enemyPokemon.currentHP} HP left.";
        if (enemyPokemon.currentHP <= 0)
        {
            battleLog.text += $"\n{enemyPokemon.name} fainted!";
        }
        else
        {
            Invoke("EnemyAttack", 1.5f); // Delay enemy attack
        }
    }

    private void EnemyAttack()
    {
        playerPokemon.TakeDamage(enemyPokemon.attackDamage);
        battleLog.text += $"\n{enemyPokemon.name} attacked! {playerPokemon.name} has {playerPokemon.currentHP} HP left.";
        if (playerPokemon.currentHP <= 0)
        {
            battleLog.text += $"\n{playerPokemon.name} fainted!";
        }
    }
}
