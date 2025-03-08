using UnityEngine;

public class BattleProximityTrigger : MonoBehaviour
{
    public GameObject pikachu; // Assign Pikachu GameObject
    public GameObject vaporeon; // Assign Vaporeon GameObject
    public GameObject battleButton; // Assign the Battle Button UI element

    public float triggerDistance = 3.0f; // Adjust this to change the required proximity

    void Start()
    {
        battleButton.SetActive(false); // Hide the button initially
    }

    void Update()
    {
        float distance = Vector3.Distance(pikachu.transform.position, vaporeon.transform.position);

        if (distance <= triggerDistance)
        {
            battleButton.SetActive(true); // Show the button when close
        }
        else
        {
            battleButton.SetActive(false); // Hide the button when far apart
        }
    }
}
