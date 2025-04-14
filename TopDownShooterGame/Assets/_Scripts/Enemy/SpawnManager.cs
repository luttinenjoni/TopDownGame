using UnityEngine;
using System.Collections;
public class SpawnManager : MonoBehaviour
{
    public GameObject ShootingSpider;
    public GameObject MeleeBat;
    public Transform[] spawnPoints; // Size = 4, drag spawn points in inspector.

    public void OrbTaken()
    {
        StartCoroutine(WaveOne());
    }

    public IEnumerator WaveOne()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(MeleeBat, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(5);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(ShootingSpider, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator WaveTwo()
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

    public IEnumerator WaveThree()
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


}