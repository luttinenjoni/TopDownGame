using UnityEngine;
using System.Collections;
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public Transform[] spawnPoints; // Size = 4, drag spawn points in inspector.

    public void OrbTaken()
    {
        StartCoroutine(WaveOne());
    }

    public IEnumerator WaveOne()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(5);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(5);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(4);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(4);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(4);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(4);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(4);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(3);

        randomIndex = Random.Range(0, spawnPoints.Length); // 0 to 3
        spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}