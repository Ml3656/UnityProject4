using UnityEngine;

public class BattleProximityTrigger : MonoBehaviour
{
    public GameObject pikachu; 
    public GameObject vaporeon; 
    public GameObject battleButton; 
    public float triggerDistance = 3.0f;
    void Start()
    {
        //battleButton.SetActive(false); 
    }

    void Update()
    {
        float distance = Vector3.Distance(pikachu.transform.position, vaporeon.transform.position);

        if (distance <= triggerDistance)
        {
            battleButton.SetActive(true); 
        }
        else
        {
            battleButton.SetActive(false);
        }
    }
}
