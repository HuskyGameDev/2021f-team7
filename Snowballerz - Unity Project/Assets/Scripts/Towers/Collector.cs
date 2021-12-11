using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : GridObject, IDamageable
{
    [SerializeField]
    [Tooltip("The maximum amount of snow the collector will hold.")]
    public int maxSnow;

    [SerializeField]
    [Tooltip("The amount of time between snow productions.")]
    public int delay;

    [SerializeField]
    [Tooltip("The amount of snow produced after delay.")]
    public int production;

    [SerializeField]
    int health;

    [SerializeField]
    int snow;

    [SerializeField]
    GameObject explosionEffect;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    SpriteRenderer fillRender;

    [SerializeField]
    Sprite[] damageSprites;

    [SerializeField]
    Sprite[] fillSprites;

    List<SpriteRenderer> srs = new List<SpriteRenderer>();

    int initialhealth;

    public GameObject Object
    {
        get { return this.gameObject; }
    }

    public void TakeDamage(int amount)
    {
        this.Health -= amount;
    }

    int Health
    {
        get { return health; }

        set
        {
            health = value;

            if (health <= 0)
            {
                health = 0;
                Die();
            }

            this.updateSprite();
        }
    }

    int Snow
    {
        get { return snow; }

        set
        {
            // Limit snow to a maxmimum of maxSnow.
            snow = Mathf.Min( value, this.maxSnow );

            updatePileSprite();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        this.updateSprite();
        this.updatePileSprite();

        StartCoroutine(CollectSnow());
    }

    IEnumerator CollectSnow()
    {
        while (true)
        {

            Snow += production;
            yield return new WaitForSeconds(delay);
        }
    }

    // Update is called once per frame
    void Awake()
    {
        this.srs.AddRange(this.GetComponentsInChildren<SpriteRenderer>());

        this.initialhealth = this.health;
    }

    void Die()
    {
        // Spawn an explosion effect.
        var explosion = GameObject.Instantiate(this.explosionEffect);

        explosion.transform.position = this.transform.position;

        Destroy(this.gameObject);
    }

    public override void Interact(Player player)
    {
        player.SnowCount += snow;

        snow = 0;

        updatePileSprite();
    }

    //Taken from tower
    private void updateSprite()
    {
        var progress = 1 - (float)this.health / (float)this.initialhealth;

        int spriteI = (int)((float)this.damageSprites.Length * progress);
        // Limit spriteI to be below damageSprite.Length.
        spriteI = Mathf.Min(spriteI, this.damageSprites.Length - 1);

        this.spriteRenderer.sprite = this.damageSprites[spriteI];
    }

    private void updatePileSprite()
    {
        var progress = (float)this.snow / (float)this.maxSnow;

        int spriteI = (int)(progress * (float)this.fillSprites.Length);

        // Limit spriteI to be below fillSprites.Length.
        spriteI = Mathf.Min(spriteI, this.fillSprites.Length - 1);

        this.fillRender.sprite = this.fillSprites[spriteI];
    }

}
