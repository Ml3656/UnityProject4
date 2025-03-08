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
    public Button startBattleButton; // Reference to the Start Battle button

    private Pokemon playerPokemon;
    private Pokemon enemyPokemon;
    private bool isPlayerTurn = true;
    private bool isBattleStarted = false; // Prevents actions before battle starts

    void Start()
    {
        battleLog.text = "Press Start to begin the battle!";
    }

    public void StartBattle()
    {
        isBattleStarted = true;
        startBattleButton.gameObject.SetActive(false); // Hide the button after starting
        playerPokemon = new Pokemon("Pikachu", 100, 20, playerHealthBar);
        enemyPokemon = new Pokemon("Vaporeon", 100, 20, enemyHealthBar);
        battleLog.text = "Battle Start! Pikachu goes first!";
    }

    public void PlayerAttack()
    {
        if (!isBattleStarted || !isPlayerTurn) return; // Prevent action if battle hasn’t started or it's not player's turn

        enemyPokemon.TakeDamage(playerPokemon.attackDamage);
        battleLog.text = $"{playerPokemon.name} attacked! {enemyPokemon.name} has {enemyPokemon.currentHP} HP left.";

        if (enemyPokemon.currentHP <= 0)
        {
            battleLog.text += $"\n{enemyPokemon.name} fainted!";
        }
        else
        {
            SwitchTurn();
        }
    }

    public void EnemyAttack()
    {
        if (!isBattleStarted || isPlayerTurn) return; // Prevent action if battle hasn’t started or it's not enemy's turn

        playerPokemon.TakeDamage(enemyPokemon.attackDamage);
        battleLog.text = $"{enemyPokemon.name} attacked! {playerPokemon.name} has {playerPokemon.currentHP} HP left.";

        if (playerPokemon.currentHP <= 0)
        {
            battleLog.text += $"\n{playerPokemon.name} fainted!";
        }
        else
        {
            SwitchTurn();
        }
    }

    private void SwitchTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        battleLog.text += $"\n{(isPlayerTurn ? "Player's" : "Enemy's")} turn!";
    }
}
