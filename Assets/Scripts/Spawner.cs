using UnityEngine;

public class Spawner : MonoBehaviour {

    private float _timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float timeDecrease;
    public float minTime;

    public GameObject[] obstacleTemplate;

    private void Start() => _timeBtwSpawns = startTimeBtwSpawns;

    private void Update() {
        if (_timeBtwSpawns <= 0) {
            var rand = Random.Range(0, obstacleTemplate.Length);
            Instantiate(obstacleTemplate[rand], transform.position, Quaternion.identity);
            _timeBtwSpawns = startTimeBtwSpawns;
            if (startTimeBtwSpawns > minTime) {
                startTimeBtwSpawns -= timeDecrease;
            }
        }
        else {
            _timeBtwSpawns -= Time.deltaTime;
        }
    }

}
