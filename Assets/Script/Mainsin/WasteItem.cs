using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteItem : GameEntity
{
    [SerializeField] protected int pointValue = 10;
    [SerializeField] protected float fallSpeed = 2f;
    [SerializeField] protected AudioClip collectSound;
    [SerializeField, Range(0f, 1f)] protected float collectVolume = 1f;
    protected string info = "Sampah terkumpul";
    protected ScoreKeeper scoreKeeper;
    protected override void Start()
    {
        base.Start();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }
    protected virtual void Update()
    {
        transform.Translate(0, -fallSpeed * Time.deltaTime,0, Space.World);
        if(transform.position.y < -6f)
        {
            scoreKeeper.AddMissed();
            Remove();
        }
    }
    void OnMouseDown()
    {
        Collect();
    }
    protected virtual void Collect()
    {
        Debug.Log(info);
        if (collectSound != null)
        {
            scoreKeeper.PlayCollectSound(collectSound, collectVolume);
        }
        scoreKeeper.AddPoints(pointValue,info);
        Remove();
    }
}
