using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour


{
    // config parametrs

    [SerializeField] AudioClip breakClip;
    [SerializeField] GameObject blokSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // cached  reference

    Level level;

    // state variables

    [SerializeField] int timesHit; 

    private void Start()
    {
        ContBreakableBlocks();
    }

    private void ContBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitsprite();            
        }
    }

    private void ShowNextHitsprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakClip, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blokSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}
