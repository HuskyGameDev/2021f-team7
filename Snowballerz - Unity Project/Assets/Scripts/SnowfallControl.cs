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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stopHere (int tileNum)
    {
	deathTiles.Add(tileNum);
    }

    public void goThroughHere (int tileNum)
    {
	deathTiles.Remove(tileNum);
    }

    void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
	ParticleSystem.ColliderData enterData;

        // list to hold entering particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        // get particles that entered trigger
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter, out enterData);

        // iterate through particles that entered
        for (int i = 0; i < numEnter; i++)
        {
        	ParticleSystem.Particle p = enter[i];
		foreach (int tile in deathTiles) 
		{
			if (enterData.GetCollider(i, 0) == ps.trigger.GetCollider(tile)) 
			{	
				p.remainingLifetime = 0;
				enter[i] = p;
				Debug.Log("Particle Killed");
			}
		}
        }
 
        // set particles
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}