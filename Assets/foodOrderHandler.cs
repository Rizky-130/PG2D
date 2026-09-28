using UnityEngine;
using Game.FoodOrdering;
public class foodOrderHandler : MonoBehaviour
{
    
    void Start()
    {
        FoodOrder order = new FoodOrder("John Doe", "Pizza", 2);
        Debug.Log($"Customer: {order.CustomerName}, Food: {order.FoodName}, Quantity: {order.FoodQuantity}");
        FoodOrder order2 = new FoodOrder("Jane Smith", "Burger", 1);
        Debug.Log($"Customer: {order2.CustomerName}, Food: {order2.FoodName}, Quantity: {order2.FoodQuantity}");
        Debug.Log(order.CustomerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
