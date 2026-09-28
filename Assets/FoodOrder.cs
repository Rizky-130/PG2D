using UnityEngine;

namespace Game.FoodOrdering
{
    public class FoodOrder
    {
        public string CustomerName;
        public string FoodName;
        public int FoodQuantity;
        
        public FoodOrder(string customerName, string foodName, int foodQuantity)
        {
            CustomerName = customerName;
            FoodName = foodName;
            FoodQuantity = foodQuantity;
        }   
    }
}