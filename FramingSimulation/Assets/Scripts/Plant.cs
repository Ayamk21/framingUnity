using UnityEngine;

public class Plant : MonoBehaviour
{
    public bool isWatered = false;
    public bool isRipe = false;

    public float growSpeed = 0.1f;   // vitesse de croissance
    public float maxScale = 1f;      // taille maximale

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // La plante grandit seulement si elle est arrosée et pas encore mûre
        if (isWatered && !isRipe)
        {
            float newSize = transform.localScale.x + growSpeed * Time.deltaTime;
            transform.localScale = new Vector3(newSize, newSize, newSize);

            if (newSize >= maxScale)
            {
                isRipe = true;
                rend.material.color = Color.yellow;
                Debug.Log("Plante mûre !");
            }
        }
    }

    public void Water()
    {
        isWatered = true;
        rend.material.color = new Color(0.1f, 0.6f, 0.2f);
        Debug.Log("Plante arrosée");
    }
}