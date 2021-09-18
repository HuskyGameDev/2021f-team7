using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnowfallControl : MonoBehaviour
{
    //List killBoxes = new List();
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* public void stopHere()
    {


    }*/

    void OnEnable()
    {
       // ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        //Debug.Log("Hello");
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        Debug.Log("numEnter = " + numEnter);
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(255, 0, 0, 255);
            enter[i] = p;
            
        }
    }
}
