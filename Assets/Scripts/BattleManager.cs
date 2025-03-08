using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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
    public TMP_Text battleLog;
    public Button startBattleButton; // Reference to the Start Battle button
    public Button playerAttack1;
    public Button playerAttack2;
    public Button enemyAttack1;
    public Button enemyAttack2;

    private Pokemon playerPokemon;
    private Pokemon enemyPokemon;
    private bool isPlayerTurn = true;
    private bool isBattleStarted = false; // Prevents actions before battle starts

    void Start()
    {
        battleLog.text = "Press Battle to begin!";
    }

    public void StartBattle()
    {
        isBattleStarted = true;
        startBattleButton.gameObject.SetActive(false); // Hide the button after starting
        playerPokemon = new Pokemon("Pikachu", 100, 20, playerHealthBar);
        enemyPokemon = new Pokemon("Vaporeon", 100, 20, enemyHealthBar);
        battleLog.text = "Battle Start! Pikachu goes first!";
        playerAttack1.gameObject.SetActive(true);
        playerAttack2.gameObject.SetActive(true);
        enemyAttack1.gameObject.SetActive(false);
        enemyAttack2.gameObject.SetActive(false);
    }

    public void PlayerAttack()
    {
        if (!isBattleStarted || !isPlayerTurn) return; // Prevent action if battle hasn’t started or it's not player's turn

        enemyPokemon.TakeDamage(playerPokemon.attackDamage);

        if (enemyPokemon.currentHP > 0)
        {
            battleLog.text = $"{playerPokemon.name} attacked! {enemyPokemon.name} has {enemyPokemon.currentHP} HP left.";
            SwitchTurn();
            playerAttack1.gameObject.SetActive(false);
            playerAttack2.gameObject.SetActive(false);
            enemyAttack1.gameObject.SetActive(true);
            enemyAttack2.gameObject.SetActive(true);
        }
        else if (enemyPokemon.currentHP <= 0)
        {
            battleLog.text = $"{enemyPokemon.name} fainted!";
            playerAttack1.gameObject.SetActive(false);
            playerAttack2.gameObject.SetActive(false);
            enemyAttack1.gameObject.SetActive(false);
            enemyAttack2.gameObject.SetActive(false);
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

        if(playerPokemon.currentHP > 0) 
        {
            battleLog.text = $"{enemyPokemon.name} attacked! {playerPokemon.name} has {playerPokemon.currentHP} HP left.";
            SwitchTurn();
            playerAttack1.gameObject.SetActive(true);
            playerAttack2.gameObject.SetActive(true);
            enemyAttack1.gameObject.SetActive(false);
            enemyAttack2.gameObject.SetActive(false);
        }
        else if (playerPokemon.currentHP <= 0)
        {
            battleLog.text = $"{playerPokemon.name} fainted!";
            playerAttack1.gameObject.SetActive(false);
            playerAttack2.gameObject.SetActive(false);
            enemyAttack1.gameObject.SetActive(false);
            enemyAttack2.gameObject.SetActive(false);
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
