using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFParticleControl : MonoBehaviour
{
    // Number of frames at which each of actions occur
    // Falls are when flakes shrink towards tiles, passes are when flakes ignore tiles
    [SerializeField]
    private int firstFallTime, firstPassTime, secondFallTime, secondPassTime;

    // The rows of tiles
    [SerializeField]
    private GameObject line1, line2, line3, line4;

    private Color tileInitColor = Color.black;

    /* Set of tiles for snowfall to stop at
     * Tiles are referred to line by line, thus line 1 contains tiles 1-8,
     *                                          line 2 contains tiles 9-16,
     *                                          line 3 contains tiles 17-24,
     *                                      and line 4 contains tiles 25-32
     * */
    HashSet<int> deathTiles = new HashSet<int>();

    int frames = 0;
    int firstDeathTile = 1;
    int secondDeathTile = 31;

    ParticleSystem straight, noise, reverseNoise;

    // Start is called before the first frame update
    void Start()
    {
        straight = this.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
        noise = this.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        reverseNoise = this.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();

        if (firstFallTime >= firstPassTime || secondFallTime >= secondPassTime)
        {
            Debug.Log("Warning: Improper input for snowfall stop and through values, switching to defaults");
            firstFallTime = 1000;
            firstPassTime = 2000;
            secondFallTime = 2500;
            secondPassTime = 3500;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update frame count and tell snow to stop or go through tiles if frame count matches given values
        frames++;
        if (frames == firstFallTime)
        {
            firstDeathTile = (int)(Random.value * 31) + 1;  // Random value between 1 and 31
            stopHere(firstDeathTile);
        }
        else if (frames == firstPassTime)
        {
            goThroughHere(firstDeathTile);
        }
        else if (frames == secondFallTime)
        {
            secondDeathTile = (int)(Random.value * 31) + 1;
            stopHere(secondDeathTile);
        }
        else if (frames == secondPassTime)
        {
            goThroughHere(secondDeathTile);
            frames = 0;
        }
    }

    private void stopHere(int tileNum)
    {
        GameObject tile = findTileObject(tileNum);
        GameObject sprite = tile.transform.Find("Sprite").gameObject;
        SpriteRenderer sr = sprite.GetComponent<SpriteRenderer>();

        if (tileInitColor == Color.black)
        {
            tileInitColor = sr.color;
        }

        sr.color = Color.cyan;

        deathTiles.Add(tileNum);
        straight.GetComponent<SnowfallControl>().stopHere(tileNum);
        noise.GetComponent<SnowfallControl>().stopHere(tileNum);
        reverseNoise.GetComponent<SnowfallControl>().stopHere(tileNum);
    }

    private void goThroughHere(int tileNum)
    {
        GameObject tile = findTileObject(tileNum);
        GameObject sprite = tile.transform.Find("Sprite").gameObject;
        SpriteRenderer sr = sprite.GetComponent<SpriteRenderer>();
        sr.color = tileInitColor;

        if (deathTiles.Contains(tileNum))
        {
            deathTiles.Remove(tileNum);
            //placeSnow(tileNum);
        }

        straight.GetComponent<SnowfallControl>().goThroughHere(tileNum);
        noise.GetComponent<SnowfallControl>().goThroughHere(tileNum);
        reverseNoise.GetComponent<SnowfallControl>().goThroughHere(tileNum);
    }

    GameObject findTileObject(int tileNum)
    {
        GameObject tile;
        int identifier;

        if (tileNum >= 1 && tileNum <= 8) // Line 1
        {
            if (tileNum <= 4)
            {
                tile = line1.transform.Find("P1:" + tileNum).gameObject;
            }
            else
            {
                identifier = tileNum - 4;
                tile = line1.transform.Find("P2:" + identifier).gameObject;
            }
        }
        else if (tileNum >= 9 && tileNum <= 16) // Line 2
        {
            if (tileNum <= 12)
            {
                identifier = tileNum - 8;
                tile = line2.transform.Find("P1:" + identifier).gameObject;
            }
            else
            {
                identifier = tileNum - 12;
                tile = line2.transform.Find("P2:" + identifier).gameObject;
            }
        }
        else if (tileNum >= 17 && tileNum <= 24) // Line 3
        {
            if (tileNum <= 20)
            {
                identifier = tileNum - 16;
                tile = line3.transform.Find("P1:" + identifier).gameObject;
            }
            else
            {
                identifier = tileNum - 20;
                tile = line3.transform.Find("P2:" + identifier).gameObject;
            }
        }
        else if (tileNum >= 25 && tileNum <= 32) // Line 4
        {
            if (tileNum <= 28)
            {
                identifier = tileNum - 24;
                tile = line4.transform.Find("P1:" + identifier).gameObject;
            }
            else
            {
                identifier = tileNum - 28;
                tile = line4.transform.Find("P2:" + identifier).gameObject;
            }
        }
        else // Error
        {
            Debug.Log("tileNum out of bounds: " + tileNum);
            return null;
        }
        return tile;
    }
}
