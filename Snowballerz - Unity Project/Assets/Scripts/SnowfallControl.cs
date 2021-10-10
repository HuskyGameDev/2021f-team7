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

	// Information on which collider the particles enter and exit
	ParticleSystem.ColliderData enterData;
	ParticleSystem.ColliderData insideData;	

        // lists to hold entering and exiting particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
	List<ParticleSystem.Particle> inside = new List <ParticleSystem.Particle>();	

        // get particles that entered trigger and those that exited trigger
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter, out enterData);
	int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside, out insideData);	

        /*// iterate through particles that entered
        for (int i = 0; i < numEnter; i++)
        {
        	ParticleSystem.Particle p = enter[i];

		if (enterData.GetCollider(i, 0) == ps.trigger.GetCollider(0) || 
		    enterData.GetCollider(i, 0) == ps.trigger.GetCollider(1))
		{
			p.remainingLifetime = 0;
			Debug.Log("Die: " + p.remainingLifetime);
			enter[i] = p;
		}
		else 
		{
			foreach (int tile in deathTiles) 
			{
				if (enterData.GetCollider(i, 0) == ps.trigger.GetCollider(tile)) 
				{	
					p.startSize = p.startSize / 1.5F;
					enter[i] = p;
				}
			}
		}
		
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);*/

 	// iterate through particles that are inside
        for (int i = 0; i < numInside; i++)
        {
        	ParticleSystem.Particle p = inside[i];
		if (insideData.GetCollider(i, 0) == ps.trigger.GetCollider(0) || 
		    insideData.GetCollider(i, 0) == ps.trigger.GetCollider(1))
		{
			p.remainingLifetime = 0;
			inside[i] = p;
		}

		foreach (int tile in deathTiles) 
		{
			if (insideData.GetCollider(i, 0) == ps.trigger.GetCollider(tile)) 
			{	
				p.startSize = p.startSize / 1.05F;
				if (p.startSize < 0.4F)
				{
					p.remainingLifetime = 0;
				}
				inside[i] = p;
			}
		}
        }

        // set particles

	ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
    }
}