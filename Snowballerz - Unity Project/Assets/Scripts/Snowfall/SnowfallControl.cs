using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnowfallControl : MonoBehaviour
{
    ParticleSystem ps;
    HashSet<int> deathTiles = new HashSet<int>();

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Set a tile number for particles to stop at
    public void stopHere (int tileNum)
    {
	    deathTiles.Add(tileNum);
    }

    // Set a tile number for particles to go through (going through tiles is default - only call this on tiles that were passed to stopHere)
    public void goThroughHere (int tileNum)
    {
	    deathTiles.Remove(tileNum);
    }

    void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

	    // Information on which collider the particles are inside
	    ParticleSystem.ColliderData insideData;

        // lists to hold inside particles
	    List<ParticleSystem.Particle> inside = new List <ParticleSystem.Particle>();	

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