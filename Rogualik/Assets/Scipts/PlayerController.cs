using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 1.5f;
    public float acceleration = 100;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        body.gravityScale = 0;
    }

    void FixedUpdate()
    {
        float v;
        float h;

        if (Input.GetKey(KeyCode.W))
        {
            v = 1;
            if (body.velocity.y > speed) body.velocity = new Vector2(body.velocity.x, speed);
            if (body.velocity.y < 0) body.velocity = new Vector2(body.velocity.x, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            v = -1;
            if (body.velocity.y < -speed) body.velocity = new Vector2(body.velocity.x, -speed);
            if (body.velocity.y > 0) body.velocity = new Vector2(body.velocity.x, 0);
        }
        else
        {
            v = 0;
            body.velocity = new Vector2(body.velocity.x, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            h = 1;
            if (body.velocity.x > speed) body.velocity = new Vector2(speed, body.velocity.y);
            if (body.velocity.x < 0) body.velocity = new Vector2(0, body.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            h = -1;
            if (body.velocity.x < -speed) body.velocity = new Vector2(-speed, body.velocity.y);
            if (body.velocity.x > 0) body.velocity = new Vector2(0, body.velocity.y);
        }
        else
        {
            h = 0;
            body.velocity = new Vector2(0, body.velocity.y);
        }

        Vector2 vector = new Vector2(h * speed, v * speed);
        body.AddForce(vector, ForceMode2D.Impulse);

        //Вращение
        //Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //dir.Normalize();
        //body.AddTorque(Vector2.SignedAngle(transform.up, dir));
        //if ((transform.up - dir).sqrMagnitude < 0.2 * 0.2)
        //{
        //    body.angularVelocity = 0;
        //}
    }

    void LookAtCursor()
    {
        //Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        //lookPos = lookPos - transform.position;
        //float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {
        //LookAtCursor();        
    }
}