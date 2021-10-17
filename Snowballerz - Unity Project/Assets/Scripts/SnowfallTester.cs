using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnowfallTester : MonoBehaviour
{
    int frames = 0;
    SnowfallControl sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SnowfallControl>();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
	if (frames % 50 == 0)
	{
		sc.stopHere(1);
	}

	if (frames % 75 == 0)
	{
		sc.goThroughHere(1);
	}

	if (frames % 30 == 0)
	{
		sc.stopHere (2);
	}

	if (frames % 101 == 0)
	{
		sc.goThroughHere(2);
	}
    }
}
