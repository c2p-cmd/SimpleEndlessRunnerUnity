using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector3 _targetPos;

    public int health;
    private string _healthString;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject spawner;
    public GameObject restartDisplay;
    private static readonly int Shake = Animator.StringToHash("shake");

    public RectTransform dPad;
    private Camera _camera;
    private bool _isCameraNotNull;

    private void Start()
    {
        _isCameraNotNull = _camera != null;
        _camera = Camera.main;
    }

    private void Awake() {
        _healthString = "♡ ♡ ♡";
    }

    private void Update() {
        if (health <= 0) { //health <= 0
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        _healthString = health switch {
            1 => "♡    ",
            2 => "♡ ♡  ",
            3 => "♡ ♡ ♡",
            _ => ""
        };
        healthDisplay.text = _healthString;

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);
        
        var up = Input.GetKeyDown(KeyCode.UpArrow) || clickUp();
        var down = Input.GetKeyDown(KeyCode.DownArrow) || clickDown();

        if (up && transform.position.y < maxY) {
            goUp();
        } else if (down && transform.position.y > minY) {
            goDown();
        }
        
        transform.position = Vector3.ClampMagnitude(transform.position, new Vector3(0f, 5f).magnitude);
    }

    private bool clickUp() {
        if (Input.touchCount == 0)
            return false;
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Ended)
            return false;
        
        var touchWorld = _camera.ScreenToWorldPoint(touch.position).y;
        var dPadWorld = _camera.ScreenToWorldPoint(dPad.position).y;
        Debug.Log(touchWorld > dPadWorld);
        return touchWorld > dPadWorld;
    }
    
    private bool clickDown() {
        if (Input.touchCount == 0)
            return false;
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Ended)
            return false;
        
        var touchWorld = _camera.ScreenToWorldPoint(touch.position).y;
        var dPadWorld = _camera.ScreenToWorldPoint(dPad.position).y;
        Debug.Log(touchWorld < dPadWorld);
        return touchWorld < dPadWorld;
    }

    private void goUp() {
        camAnim.SetTrigger(Shake);
        var position = transform.position;
        Instantiate(moveEffect, position, Quaternion.identity);
        _targetPos = new Vector3(position.x, position.y + increment);
    }

    private void goDown() {
        camAnim.SetTrigger(Shake);
        var position = transform.position;
        Instantiate(moveEffect, position, Quaternion.identity);
        _targetPos = new Vector3(position.x, position.y - increment);
    }
}
