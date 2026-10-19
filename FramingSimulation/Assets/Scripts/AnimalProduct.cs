using UnityEngine;

public class AnimalProduct : MonoBehaviour
{
    public GameObject eggPrefab;
    public float productInterval = 5f;

    private float timer;
    private GameObject currentEgg;
    private AnimalNeeds needs;

    void Start()
    {
        needs = GetComponent<AnimalNeeds>();
    }

    void Update()
    {
        // Si un oeuf existe déjà, on attend qu'il soit ramassé
        if (currentEgg != null) return;

        timer += Time.deltaTime;

        if (timer >= productInterval && needs.hunger > 30f)
        {
            currentEgg = Instantiate(eggPrefab, transform.position + Vector3.up * 0.2f, Quaternion.identity);
            timer = 0f;
        }
    }
}