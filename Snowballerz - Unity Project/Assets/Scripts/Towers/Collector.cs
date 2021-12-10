using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : GridObject, IDamageable
{
    
    enum FillStatus
    {
        STATUS_EMPTY = 0,
        STATUS_PART,
        STATUS_NEARFULL,
        STATUS_FULL
    }

    [SerializeField]
    public int maxSnow;

    [SerializeField]
    public int delay;

    [SerializeField]
    public int production;

    [SerializeField]
    int health;

    [SerializeField]
    int snow;

    [SerializeField]
    int fillState;

    [SerializeField]
    GameObject explosionEffect;

    [SerializeField]
    int initialhealth;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    SpriteRenderer fillRender;

    [SerializeField]
    Sprite[] damageSprites;

    [SerializeField]
    Sprite[] fillSprites;

    List<SpriteRenderer> srs = new List<SpriteRenderer>();

    public GameObject Object => throw new System.NotImplementedException();

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

            if (snow < maxSnow)
            {

                snow = value;

                if (snow > (maxSnow / 2))
                {
                    fillState = (int)FillStatus.STATUS_NEARFULL;
                } else
                {
                    fillState = (int)FillStatus.STATUS_PART;
                }

                updatePileSprite();
         
            } else
            {
                snow = maxSnow;
                fillState = (int)FillStatus.STATUS_FULL;
                updatePileSprite();
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        this.updateSprite();

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

        fillState = (int)FillStatus.STATUS_EMPTY;
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
        fillState = (int)FillStatus.STATUS_EMPTY;
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
        this.fillRender.sprite = this.fillSprites[fillState];
    }

}
