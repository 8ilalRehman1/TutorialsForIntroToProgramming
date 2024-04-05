using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.UI;

public class Player : MonoBehaviour
{
    [Header("Camera")]

    [SerializeField, Range(1,20)] private float mouseSenseX;

    [SerializeField, Range (1,20)] private float mouseSenseY;

    [SerializeField, Range(0, 90)] private float maxViewAngle;

    [SerializeField, Range(-90, 0)] private float minViewAngle;

    [SerializeField] private Transform followTarget;

    private Vector2 currentAngle;

    [Header("Shooting")]

    [SerializeField] private Rigidbody bulletPrefab;

    [SerializeField] private float projectileForce;

    [SerializeField] private Camera playerCamera;

    [SerializeField] private float speed;

    //THIS is the variable speed for my charecter
    public GameObject projectile;

    public Transform projectilePos;

    private int ammo = 30;

    private bool canShoot = true;

    [Header("Player UI")]

    [SerializeField] private UnityEngine.UI.Image healthbar;
    [SerializeField] private TextMeshProUGUI shotsFired;
    [SerializeField] private TextMeshProUGUI showAmmo;
    [SerializeField] private float maxHealth;
    private int shotsFiredCounter;
    private float _health;

    private float Health
    {
        get=>_health;
        set
        {
            _health = value;
            healthbar.fillAmount = _health / maxHealth;
        }
    }
    Vector2 rotate;

    Rigidbody rb;

    //this is the vaiable for the rigid body this is needed for jump

    public float jump = 5f;

    //this is for how much the cube will jump

    private Vector3 moveDirection;

    //this is a veriable for the vactor pos

    bool isGrounded;

    //this is needed to see if the char can jump or not

    private int _coinCounter;

    //this will count the coins

    // Start is called before the first frame update
    void Start()
    {
        //InputManager.Init(this);
        //calls intit and sets it to this
        InputManager.SetGameControls();
        //calls SetGameConrols
        rb = GetComponent<Rigidbody>();
        //this adds the rigid body as a component
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += followTarget.rotation * (speed * Time.deltaTime * moveDirection);
        //this chaneges the pos
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y);
        //this is to check if the payer is on the floor

        Health -= Time.deltaTime * 5;
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }
    //the fucntion above is to make the cahr jump
    public void SetMovementDirection(Vector3 currentDirection)
    {
        moveDirection = currentDirection;
    }
    //this fucntion above is to cahnge the movement

    public void SetLook(Vector2 readValue
        )
    {
        currentAngle.x += readValue.x * Time.deltaTime * mouseSenseX;
        currentAngle.y += readValue.y * Time.deltaTime * mouseSenseY;

        currentAngle.y = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle);

        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);

    }


    public void Shoot()
    {
        if (ammo > 0)
        {
            if (canShoot)
            {
                Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                currentProjectile.AddForce(followTarget.forward * projectileForce, ForceMode.Impulse);

                ++shotsFiredCounter;

                shotsFired.text = shotsFiredCounter.ToString();

                showAmmo.text = ammo.ToString();

                Destroy(currentProjectile.gameObject, 4);

                ammo--;
            }
        }

    }

    public void Reload()
    {
        ammo = ammo + 30;
    }
}