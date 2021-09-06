using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float PlayerSpeed;
    private float xAxis;
    private float zAxis;
    public MobData Data;
    public float DashSpeed;
    public float DashTime;
    private bool isDashing;
    private int lastStepSound, newStepSound;
    [SerializeField] AudioSource DashSound;
    [SerializeField] ParticleSystem DashParticleSystem;
    [SerializeField] AudioClip[] stepSounds;
    [SerializeField] AudioSource StepSound;
    Vector3 dir;
    Vector3 velocity;
    private Rigidbody rb;
    public float TurnSpeed;
    public LayerMask LayerMask;
    float test;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!isDashing)
            {
                StartCoroutine(Dashing());
            }
        }
        
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            Run(dir);
        }        
    }

    private void Run(Vector3 dir)
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        dir = new Vector3(xAxis, 0, zAxis);
        dir.Normalize();

        rb.velocity = (new Vector3(dir.x * PlayerSpeed, 0, dir.z * PlayerSpeed));
    }

    private void RotatePlayer() //methode von Maik ps. Maik ist doof!
    {
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, LayerMask))
        {
            Vector3 targetPoint = raycastHit.point;
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
        }
    }

    private void MakeStepSound()
    {
        do
        {
            newStepSound = Random.Range(0, stepSounds.Length - 1);
        } while (newStepSound == lastStepSound);        
        lastStepSound = newStepSound;        
        
        StepSound.PlayOneShot(stepSounds[lastStepSound]);
    }

    IEnumerator Dashing()
    {
        isDashing = true;
        Data.IsInvincible = true;
        DashSound.Play();
        if (xAxis != 0 || zAxis != 0)
        {
            rb.AddForce(new Vector3(xAxis, 0, zAxis).normalized * DashSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(DashTime);
        }
        else
        {
            rb.AddForce(transform.forward * DashSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(DashTime);
        }
        isDashing = false;
        Data.IsInvincible = false;
    }
}
