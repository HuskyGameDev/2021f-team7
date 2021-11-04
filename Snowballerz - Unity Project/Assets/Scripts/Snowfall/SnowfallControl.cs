using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowfallControl : MonoBehaviour
{
    [SerializeField]
    private GridObject snowTile;

    // The rows of tiles
    [SerializeField]
    private GameObject line1;
    [SerializeField]
    private GameObject line2;
    [SerializeField]
    private GameObject line3;
    [SerializeField]
    private GameObject line4;

    public int firstStop;
    public int firstThrough;
    public int secondStop;
    public int secondThrough;

    ParticleSystem ps;

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

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();  // Grab the particle system this script is attached to

        if(firstStop >= firstThrough || secondStop >= secondThrough)
        {
            Debug.Log("Warning: Improper input for snowfall stop and through values, snowfall will not work correctly");
        }
    }

    void Update()
    {
        // Update frame count and tell snow to stop or go through tiles if frame count matches given values
        frames++;
        if (frames == firstStop)
        {
            firstDeathTile = (int)(Random.value * 32);
            stopHere(firstDeathTile);
        }
        else if (frames == firstThrough)
        {
            goThroughHere(firstDeathTile);
        }
        else if (frames == secondStop)
        {
            secondDeathTile = (int)(Random.value * 32);
            stopHere(secondDeathTile);
        }
        else if (frames == secondThrough)
        {
            goThroughHere(secondDeathTile);
            frames = 0;
        }
    }

    // Set a tile number for particles to stop at
    public void stopHere(int tileNum)
    {
        deathTiles.Add(tileNum);
    }

    // Set a tile number for particles to go through (going through tiles is default - only call this on tiles that were passed to stopHere)
    public void goThroughHere(int tileNum)
    {
        if (deathTiles.Contains(tileNum))
        {
            deathTiles.Remove(tileNum);
            placeSnow(tileNum);
        }
    }

    // Place down snow tile at given tile number
    /* 
     * Options for when to call this function: 
     *      on call to goThroughHere()
     *      after tile has received some amount of time with snow falling on it
     *      random chance while snowfall is occurring 
     */
    // Issue to bring up: rename of tiles
    void placeSnow(int tileNum)
    {
        GameObject tile;
        int identifier;

        // Find specific tile to operate on       
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
            Debug.Log("placeSnow out of bounds: " + tileNum);
            return;
        }
        // Tile has now been found (or an error occurred and the function stopped)

        // Tell tile to place down a snow tile if no other object exists on it
        if (!tile.GetComponent<GridSquare>().HasCurrentObject())
        {
            tile.GetComponent<GridSquare>().Place(snowTile);
        }
    }

    void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        // Information on which collider the particles are inside
        ParticleSystem.ColliderData insideData;

        // lists to hold inside particles
        List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

        // get particles that are inside trigger
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside, out insideData);

        // iterate through particles that are inside
        for (int i = 0; i < numInside; i++)
        {

            ParticleSystem.Particle p = inside[i];
            int colliderNum = insideData.GetColliderCount(i);

            // Particle outside bounds
            if (colliderNum == 1)
            {
                p.remainingLifetime = 0;
                inside[i] = p;
                break;
            }

            // Particle in more than one collider (inside a tile)
            if (colliderNum > 2)
            {
                // Iterate through each tile on which particles should die
                foreach (int tile in deathTiles)
                {
                    if (insideData.GetCollider(i, 0) == ps.trigger.GetCollider(tile) || insideData.GetCollider(i, 1) == ps.trigger.GetCollider(tile))
                    {
                        p.startSize = p.startSize / 1.05F;
                        if (p.startSize < 0.4F)
                        {
                            p.remainingLifetime = 0;
                        }
                        inside[i] = p;
                        break;
                    }
                } // End of foreach deathtile
            }
        } // End of for each particle inside

        // set particles
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
    }
}