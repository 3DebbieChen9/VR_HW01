using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class BubbleGun : MonoBehaviour
{
    XRGrabInteractable m_InteractableBase;
    
    [SerializeField] ParticleSystem m_BubbleParticleSystem = null;

    const string k_AnimTriggerDown = "TriggerDown";
    const string k_AnimTriggerUp = "TriggerUp";
    const float k_HeldThreshold = 0.05f;

    float m_TriggerHeldTime;
    bool m_TriggerDown;

    public GameObject weaponSwitchProvider;
    private float button_N_value;
    private bool weaponSwitch = true;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private bool canShoot = true;
    private float currentTime;

    protected void Start()
    {
        m_InteractableBase = GetComponent<XRGrabInteractable>();
        m_InteractableBase.selectExited.AddListener(DroppedGun);
        m_InteractableBase.activated.AddListener(TriggerPulled);
        m_InteractableBase.deactivated.AddListener(TriggerReleased);
    }

    protected void Update()
    {
        button_N_value = weaponSwitchProvider.GetComponent<ActionBasedWeaponSwitchProvider>().ReadInput();
        if (button_N_value == 1)
        {
            weaponSwitch = !weaponSwitch;
        }
        if (m_TriggerDown)
        {
            m_TriggerHeldTime += Time.deltaTime;

            if (m_TriggerHeldTime >= k_HeldThreshold)
            {
                if(weaponSwitch)
                {
                    if (!m_BubbleParticleSystem.isPlaying)
                    {
                        m_BubbleParticleSystem.Play();
                    }
                }
                else
                {
                    if (canShoot == true)
                    {
                        GameObject newBullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                        currentTime = Time.time;
                        canShoot = false;
                        // Add force to the fire
                        newBullet.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 500);
                    }
                }
            }
        }
        if (Time.time - currentTime >= 2.0f)
        {
            canShoot = true;
        }
    }

    void TriggerReleased(DeactivateEventArgs args)
    {
        //m_Animator.SetTrigger(k_AnimTriggerUp);
        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;
        m_BubbleParticleSystem.Stop();
        //print("Trigger Released");
    }

    void TriggerPulled(ActivateEventArgs args)
    {
        //m_Animator.SetTrigger(k_AnimTriggerDown);
        m_TriggerDown = true;
        //print("Trigger Pulled");
    }

    void DroppedGun(SelectExitEventArgs args)
    {
        // In case the gun is dropped while in use.
        //m_Animator.SetTrigger(k_AnimTriggerUp);

        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;
        m_BubbleParticleSystem.Stop();
    }

    public void ShootEvent()
    {
        m_BubbleParticleSystem.Emit(1);
    }
}
