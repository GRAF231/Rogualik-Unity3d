using UnityEngine;


namespace TheGame
{
    public class CameraFollower : MonoBehaviour
    {
        public Player Followed;
        public float CameraPositionLerp = 0.02f;
        private Camera _camera;

        Vector2 minCameraPos, maxCameraPos;

        private static CameraFollower instance = null;
        public static CameraFollower Instance
        {
            get
            {
                return instance;
            }
        }
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            DontDestroyOnLoad(this);
            instance = this;
        }

        private void OnEnable()
        {
            _camera = GetComponent<Camera>();
        }
        public void StartGame()
        {
            _camera.transform.position = Vector2.zero;
            //maxCameraPos = new Vector2(Arena.max.x - _camera.ViewportToWorldPoint(new Vector2(1, 1)).x, Arena.max.y - _camera.ViewportToWorldPoint(new Vector2(1, 1)).y);
            //minCameraPos = new Vector2(Arena.min.x - _camera.ViewportToWorldPoint(new Vector2(0, 0)).x, Arena.min.y - _camera.ViewportToWorldPoint(new Vector2(0, 0)).y);
        }
        private void Update()
        {
            if (Followed != null)
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(Followed.transform.position.x, Followed.transform.position.y, -10), CameraPositionLerp * Time.deltaTime);

                //_camera.transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), -10);
            }
        }
    }

}