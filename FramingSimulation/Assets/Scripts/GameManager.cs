using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI messageText;

    private int money = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateMoney();
        ShowMessage("Bienvenue à la ferme !");
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoney();
    }

    void UpdateMoney()
    {
        moneyText.text = "Argent : " + money;
    }

    public void ShowMessage(string msg)
    {
        messageText.text = msg;
    }
}