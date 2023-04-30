using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightRadius : MonoBehaviour
{
    public float lightradius;
    public float defaultradius;
    public float radiusdecreaserate;
    public GameObject pointlight;
    public Light2D light2D;
    public AudioSource pickupsound;
    public AudioClip audioclip1;
    public AudioClip audioclip2;
    public AudioClip audioclip3;
    // Start is called before the first frame update
    void Start()
    {
        lightradius = defaultradius;
        light2D = pointlight.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RadiusDecrease();
        light2D.pointLightOuterRadius = lightradius;
        if(!(lightradius > 2.5f))
        {
            GameManager.Player.Die();
        }
    }
    public void RadiusDecrease()
    {
        if(lightradius > 0f)
        {
            lightradius -= radiusdecreaserate * Time.deltaTime;
        }
    }
    IEnumerator RadiusIncrease()
    {   
        while(lightradius < defaultradius)
        {
            lightradius += radiusdecreaserate * 10f * Time.deltaTime;
            yield return null;
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Candle" && collision.GetComponent<Candle>().isonfire != true)
        {
            collision.GetComponent<Candle>().isonfire = true;
            collision.GetComponent<Candle>().DestroyLight();
            StartCoroutine(RadiusIncrease());
            int x = (int)Random.Range(1f, 4f);
            switch (x)
            {
                case 1:
                    pickupsound.clip = audioclip1;
                    break;
                case 2:
                    pickupsound.clip = audioclip2;
                    break;
                case 3:
                    pickupsound.clip = audioclip3;
                    break;
            }
            pickupsound.Play();
        }
        if(collision.tag == "Firefly")
        {
            defaultradius += 1.5f;
            StartCoroutine(RadiusIncrease());
            Destroy(collision.gameObject);
            int x = (int)Random.Range(1f, 4f);
            switch (x)
            {
                case 1:
                    pickupsound.clip = audioclip1;
                    break;
                case 2:
                    pickupsound.clip = audioclip2;
                    break;
                case 3:
                    pickupsound.clip = audioclip3;
                    break;
            }
            pickupsound.Play();
        }
    }
}
