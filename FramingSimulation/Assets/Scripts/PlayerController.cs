using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        movement = new Vector3(h, 0f, v).normalized;

        // G : nourrir les animaux proches
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
            foreach (GameObject a in animals)
            {
                if (Vector3.Distance(transform.position, a.transform.position) < 3f)
                {
                    a.GetComponent<AnimalNeeds>().Feed();
                    GameManager.instance.ShowMessage("Animal nourri !");
                }
            }
        }

        // H : ramasser les oeufs proches
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject[] eggs = GameObject.FindGameObjectsWithTag("Egg");
            foreach (GameObject e in eggs)
            {
                if (Vector3.Distance(transform.position, e.transform.position) < 3f)
                {
                    Destroy(e);
                    GameManager.instance.AddMoney(5);
                    GameManager.instance.ShowMessage("Oeuf collecté ! +5");
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}