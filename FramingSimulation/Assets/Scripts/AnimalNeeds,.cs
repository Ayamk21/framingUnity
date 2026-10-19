using UnityEngine;

public class AnimalNeeds : MonoBehaviour
{
    public float hunger = 100f;
    public float decreaseSpeed = 5f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        hunger -= decreaseSpeed * Time.deltaTime;
        hunger = Mathf.Clamp(hunger, 0f, 100f);

        // Plus l'animal a faim, plus il devient rouge
        rend.material.color = Color.Lerp(Color.red, Color.white, hunger / 100f);
    }

    public void Feed()
    {
        hunger = 100f;
    }
}