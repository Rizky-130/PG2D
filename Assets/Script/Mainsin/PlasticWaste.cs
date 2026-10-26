using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlasticWaste : WasteItem
{
    
    protected override void Collect()
    {
        info = "Plastik: didaur ulang (+" + pointValue
        + " poin)";
        base.Collect();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Collect();
        }
    }
    
}
