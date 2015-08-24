using UnityEngine;
using System.Collections;

public class INpcSpawn : Item {
    public enum SpawnType
    {
        APPLE,
        ORANGE
    }

    public SpawnType spawnType = SpawnType.APPLE;
    public bool dontWaitAtStart = false;
    public float frequency = 10;
    public float frecuencyVariation = 2;

    private Character prefab;

	void Start () {
        switch (spawnType) {
            case SpawnType.APPLE:
                prefab = Cache.Get.apple;
                break;
            case SpawnType.ORANGE:
                prefab = Cache.Get.orange;
                break;
        }



        StartCoroutine(SpawnCicle());
	}

    private IEnumerator SpawnCicle() {
        float seconds = frequency + Random.Range(-frecuencyVariation, frecuencyVariation);
        yield return new WaitForSeconds(dontWaitAtStart? Random.Range(0, frecuencyVariation) : seconds);
        Spawn();

        while (true)
        {
            yield return new WaitForSeconds(frequency + Random.Range(-frecuencyVariation, frecuencyVariation));

            Spawn();
        }
    }

    public void Spawn() {
        Vector3 position = transform.position;
        position.x += Random.Range(-1f, 1f);
        position.z += Random.Range(-1f, 1f);

        Instantiate(prefab, position, transform.rotation);
    }
}
