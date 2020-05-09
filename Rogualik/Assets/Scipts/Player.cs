using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Transform hat;
    void Start()
    {
        hat.localPosition = new Vector2(0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
