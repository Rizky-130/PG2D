using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicItem : WasteItem
{
    protected override void Collect()
    {
        info = "Organik: olah menjadi kompos (+"
+ pointValue + " poin)";
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
