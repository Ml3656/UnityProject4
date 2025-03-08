using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public GameObject battleButton; 
    public GameObject pikachuBattleBar; 
    public GameObject vaporeonBattleBar; 
    public GameObject pikachuTailWhap; 
    public GameObject pikachuThunder; 
    public GameObject vaporeonSpiralDrain; 
    public GameObject vaporeonFightingWhirlpool; 
    public AudioSource audioSource;


    void Start()
    {
        battleButton.SetActive(true);
        pikachuBattleBar.SetActive(false);
        vaporeonBattleBar.SetActive(false);
        pikachuTailWhap.SetActive(false);
        pikachuThunder.SetActive(false);
        vaporeonSpiralDrain.SetActive(false);
        vaporeonFightingWhirlpool.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void StartBattle()
    {
        battleButton.SetActive(false);
        pikachuBattleBar.SetActive(true); 
        vaporeonBattleBar.SetActive(true); 
        pikachuTailWhap.SetActive(true);
        pikachuThunder.SetActive(true);
        vaporeonSpiralDrain.SetActive(true);
        vaporeonFightingWhirlpool.SetActive(true);
    }

    public void PlayTrack(){
        audioSource.Play();
    }
}
