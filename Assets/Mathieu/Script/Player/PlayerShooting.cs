using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.25f;
    public float range = 100f;
    public VRTK.VRTK_ControllerEvents controllerEvent;

    public int nombreMunition = 5;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    //ParticleSystem gunParticles;
    LineRenderer gunLine;
    //AudioSource gunAudio;
    //Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        //shootableMask = LayerMask.GetMask ("Shootable");
        //gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        //gunAudio = GetComponent<AudioSource> ();
        //gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if((Input.GetButtonDown("Fire1") || controllerEvent.triggerTouched) && timer >= timeBetweenBullets && Time.timeScale != 0 && nombreMunition > 0)
        {
            
            Debug.Log(nombreMunition);
            Shoot();
           
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        //gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;
        nombreMunition --;
        //gunAudio.Play ();

        //gunLight.enabled = true;

        //gunParticles.Stop ();
        // gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range))
        {
            DegatsSurEnnemi health = shootHit.collider.GetComponent<DegatsSurEnnemi>();
            
            if (health != null)
            {
                health.Damage (damagePerShot);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
