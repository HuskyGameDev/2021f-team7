using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAE : MonoBehaviour
{

    [ SerializeField ]
    private AudioSource walkSound;

    public void PlayWalkSound()
    {
        walkSound.Play();
    }
}
