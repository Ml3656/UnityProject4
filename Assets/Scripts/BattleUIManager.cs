using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public GameObject battleButton; // Assign the "Battle" button
    public GameObject pikachuBattleBar; // Assign Pikachu's battle bar
    public GameObject vaporeonBattleBar; // Assign Vaporeon's battle bar
    public GameObject pikachuTailWhap; 
    public GameObject pikachuThunder; 
    public GameObject vaporeonSpiralDrain; 
    public GameObject vaporeonFightingWhirlpool; 

    void Start()
    {
        // Ensure only the button is visible at the start
        battleButton.SetActive(true);
        pikachuBattleBar.SetActive(false);
        vaporeonBattleBar.SetActive(false);
        pikachuTailWhap.SetActive(false);
        pikachuThunder.SetActive(false);
        vaporeonSpiralDrain.SetActive(false);
        vaporeonFightingWhirlpool.SetActive(false);
    }

    // Call this method when the button is pressed
    public void StartBattle()
    {
        battleButton.SetActive(false); // Hide the battle button
        pikachuBattleBar.SetActive(true); // Show Pikachu's battle bar
        vaporeonBattleBar.SetActive(true); // Show Vaporeon's battle bar
        pikachuTailWhap.SetActive(true);
        pikachuThunder.SetActive(true);
        vaporeonSpiralDrain.SetActive(true);
        vaporeonFightingWhirlpool.SetActive(true);
    }
}
