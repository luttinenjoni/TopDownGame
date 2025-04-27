using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoBehaviour
{
    public GameObject ShootingSpider;
    public GameObject MeleeBat;
    public GameObject MeleeRaven;
    public GameObject Skeleton; // Add this line to declare the Skeleton prefab
    public Transform[] spawnPoints; // Size = 4, drag spawn points in inspector.
    public string currentScene;

    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level2")
        {
            StartCoroutine(L2W1());
        }
    }

    public void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void OrbTaken()
    {
        StartCoroutine(L1W1());
    }

    public IEnumerator L1W1()
    {

        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(MeleeBat, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(5);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(ShootingSpider, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L1W2()
    {
        Debug.Log("Wave 2 begun");
        yield return new WaitForSeconds(2);

        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(MeleeBat, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(2);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(MeleeBat, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(4);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(ShootingSpider, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(ShootingSpider, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(MeleeBat, spawnPoint.position, spawnPoint.rotation);

    }

    public IEnumerator L1W3()
    {
        yield return new WaitForSeconds(2);

        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(ShootingSpider, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(MeleeBat, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(ShootingSpider, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(ShootingSpider, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(ShootingSpider, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L2W1()
    {
        yield return new WaitForSeconds(2);

        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(MeleeBat, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(Skeleton, spawnPoint.position, spawnPoint.rotation);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(Skeleton, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(3);
    }


}