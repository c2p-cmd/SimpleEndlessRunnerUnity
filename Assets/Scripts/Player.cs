using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 _targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject spawner;
    public GameObject restartDisplay;
    private static readonly int Shake = Animator.StringToHash("shake");

    private void Update() {
        if (health <= 0) {
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();

        transform.position = Vector2.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
            camAnim.SetTrigger(Shake);
            var position = transform.position;
            Instantiate(moveEffect, position, Quaternion.identity);
            _targetPos = new Vector2(position.x, position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            camAnim.SetTrigger(Shake);
            var position = transform.position;
            Instantiate(moveEffect, position, Quaternion.identity);
            _targetPos = new Vector2(position.x, position.y - increment);
        }
    }
}
