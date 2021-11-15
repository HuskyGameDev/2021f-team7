using System.Collections;
using UnityEngine;

public class Burnable : MonoBehaviour
{
    int burnDamage = 5;
    float burnTimer = 1.5f;

    Tower tower;

    bool isBurned = false;

    void Start()
    {
        tower = GetComponent<Tower>();   
    }

    public bool IsBurned
    {
        get { return isBurned; }

        set
        {
            isBurned = value;

            if (value == true)
            {
                StartCoroutine(Burn());
            }
        }
    }

    IEnumerator Burn()
    {
        while(true)
        {
            yield return new WaitForSeconds(burnTimer);
            tower.TakeDamage(burnDamage);
            
        }
    }

    void ChangeColor()
    {
        tower.sprite.color = Color.red;
    }
}