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
    //private int lastStepSound, newStepSound;
    [SerializeField] AudioSource DashSound;
    [SerializeField] ParticleSystem DashParticleSystem;
    [SerializeField] AudioClip[] stepSounds;
    [SerializeField] AudioSource StepSound;
    Vector3 dir;
    //Vector3 velocity;
    private Rigidbody rb;
    public float TurnSpeed;
    public LayerMask LayerMask;
    float test;
    public GameObject GroundCheck;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //RaycastHit Hit;
        //if (Physics.SphereCast(GroundCheck.transform.position,0.2f, GroundCheck.transform.position, out Hit))
        //{
        //    if(Hit.collider.CompareTag("World"))
        //    {

        //        //rb.AddForce(new Vector3(0, 5, 0).normalized * 6, ForceMode.Impulse);
        //        Debug.Log("SHEEESH");
        //    }
        //}

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
        //MakeStepSound();
        if(zAxis == 0 && zAxis == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        rb.velocity = (new Vector3(dir.x * PlayerSpeed, rb.velocity.y , dir.z * PlayerSpeed));
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

    //private void MakeStepSound()
    //{
    //    StepSound.PlayOneShot(stepSounds[Random.Range(0, stepSounds.Length)]);

        //do
        //{
        //    newStepSound = Random.Range(0, stepSounds.Length - 1);
        //} while (newStepSound == lastStepSound);        
        //lastStepSound = newStepSound;        
        //
        //StepSound.PlayOneShot(stepSounds[lastStepSound]);
    //

    IEnumerator Dashing()
    {
        while(isDashing)
        {
            rb.velocity.y.Equals(0);
        }
        Instantiate(DashParticleSystem,transform.position,transform.rotation);
        rb.velocity = new Vector3(0, 0, 0);
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
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GroundCheck.transform.position, 0.2f);
    }
}
