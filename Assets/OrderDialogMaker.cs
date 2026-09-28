using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Game.FoodOrdering;

public class OrderDialogMaker : MonoBehaviour
{
    public TextMeshProUGUI customerNameText;
    public TextMeshProUGUI foodNameText;
    public Button showOrderButton;

    public void SetOrderDetails(string customerName, string foodName)
    {
        if (customerNameText != null)
        {
            customerNameText.text = customerName;
        }

        if (foodNameText != null)
        {
            foodNameText.text = foodName;
        }
    }
    void Start()
    {
        FoodOrder order = new FoodOrder("Jane Smith", "Burger", 1);
        // SetOrderDetails(order.CustomerName, order.FoodName + " x" + order.FoodQuantity);
        showOrderButton.onClick.AddListener(() => SetOrderDetails(order.CustomerName, order.FoodName + " x" + order.FoodQuantity));
    }
}
