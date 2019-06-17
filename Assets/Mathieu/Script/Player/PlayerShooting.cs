using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.25f;
    public float range = 100f;
    public VRTK.VRTK_ControllerEvents controllerEvent;
    public Inventory tir;
    public int nombreMunition = 10;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    //ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    //Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {

        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();

    }


    void Update()
    {
        timer += Time.deltaTime;

        if (tir.pistoletEnMain == true)
        {
            
            if ((Input.GetButtonDown("Fire1") || controllerEvent.triggerTouched) && timer >= timeBetweenBullets && Time.timeScale != 0 && nombreMunition > 0)
            {

                Debug.Log(nombreMunition);
                Shoot();

            }

            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                DisableEffects();
            }
        }
    }

    public void DisableEffects ()
    {
        gunLine.enabled = false;
        
    }


    void Shoot ()
    {
        timer = 0f;
        nombreMunition --;
        FindObjectOfType<AuidoManager>().Play("Pistolet");



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
