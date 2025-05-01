using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoBehaviour
{
    public GameObject ShootingSpider;
    public GameObject MeleeBat;
    public GameObject MeleeRaven;
    public GameObject PumpkinMan;
    public GameObject FrostWolf;
    public GameObject MrFrost;
    public GameObject SnowRat;
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
        if (currentScene == "Level3")
        {
            StartCoroutine(L3W1());
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

        Instantiate(MeleeRaven, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(MeleeRaven, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(4);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(Skeleton, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L2W2()
    {
        yield return new WaitForSeconds(2);
        Transform spawnPoint = spawnPoints[0];
        Instantiate(Skeleton, spawnPoint.position, spawnPoint.rotation);
        spawnPoint = spawnPoints[2];
        Instantiate(Skeleton, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(3);
        spawnPoint = spawnPoints[1];
        Instantiate(MeleeRaven, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L2W3()
    {
        yield return new WaitForSeconds(2);
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(PumpkinMan, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(5);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(MeleeRaven, spawnPoint.position, spawnPoint.rotation);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(MeleeRaven, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(10);

    }

    public IEnumerator L2W4()
    {
        yield return new WaitForSeconds(2);
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(PumpkinMan, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(5);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(Skeleton, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(2);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(MeleeRaven, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L3W1()
    {
        yield return new WaitForSeconds(3);
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(SnowRat, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(2);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(MrFrost, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L3W2()
    {
        yield return new WaitForSeconds(1);
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(SnowRat, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(2);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(FrostWolf, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(2);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(SnowRat, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L3W3()
    {
        yield return new WaitForSeconds(2);
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(SnowRat, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(1);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(MrFrost, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(2);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(SnowRat, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L3W4()
    {
        yield return new WaitForSeconds(2);
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];
        spawnPoint = spawnPoints[0];
        Instantiate(FrostWolf, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(1);
        spawnPoint = spawnPoints[2];
        Instantiate(FrostWolf, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(2);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(MrFrost, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(4);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(SnowRat, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator L3W5()
    {
        yield return new WaitForSeconds(1);
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];
        spawnPoint = spawnPoints[1];
        Instantiate(MrFrost, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(1);
        spawnPoint = spawnPoints[3];
        Instantiate(MrFrost, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(4);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(FrostWolf, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(3);
        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];
        Instantiate(SnowRat, spawnPoint.position, spawnPoint.rotation);
    }
}