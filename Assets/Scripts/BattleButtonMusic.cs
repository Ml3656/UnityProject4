using UnityEngine;
using UnityEngine.UI;

public class BattleButtonMusic : MonoBehaviour
{
    public AudioSource battleMusic;
    public GameObject battleButton;

    void Start()
    {
        battleButton.GetComponent<Button>().onClick.AddListener(PlayBattleMusic);
    }

    void PlayBattleMusic()
    {
        if (battleMusic != null)
        {
            battleMusic.Stop(); 
            battleMusic.Play();  
        }
    }
}