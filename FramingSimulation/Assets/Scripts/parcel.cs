using UnityEngine;

public class Parcel : MonoBehaviour
{
    public bool playerNearby;
    public GameObject plantPrefab;
    public Color normalColor = new Color(0.45f, 0.27f, 0.1f);
    public Color highlightColor = new Color(0.7f, 0.45f, 0.2f);

    private Renderer rend;
    private GameObject currentPlant;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = normalColor;
    }

    void Update()
    {
        if (!playerNearby) return;

        // E : planter
        if (Input.GetKeyDown(KeyCode.E) && currentPlant == null)
        {
            Vector3 pos = transform.position + new Vector3(0f, 0.3f, 0f);
            currentPlant = Instantiate(plantPrefab, pos, Quaternion.identity);
            Debug.Log("Graine plantée");
        }

        // F : arroser
        if (Input.GetKeyDown(KeyCode.F) && currentPlant != null)
        {
            currentPlant.GetComponent<Plant>().Water();
        }

        // R : récolter (seulement si la plante est mûre)
        if (Input.GetKeyDown(KeyCode.R) && currentPlant != null)
        {
            if (currentPlant.GetComponent<Plant>().isRipe)
            {
                Destroy(currentPlant);
                currentPlant = null;
                Debug.Log("Récolte réussie !");
            }
            else
            {
                Debug.Log("La plante n'est pas encore mûre");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            rend.material.color = highlightColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            rend.material.color = normalColor;
        }
    }
}