using UnityEngine;
using System.Collections;

public class INpcSpawn : Item {

    public float frequency = 10;
    public float frecuencyVariation = 2;

	void Start () {
        StartCoroutine(SpawnCicle());
	}

    private IEnumerator SpawnCicle() {
        while (true)
        {
            yield return new WaitForSeconds(frequency + Random.Range(-frecuencyVariation, frecuencyVariation));

            Vector3 position = transform.position;
            position.x += Random.Range(-1f, 1f);
            position.z += Random.Range(-1f, 1f);

            Instantiate(Cache.Get.apple, position, transform.rotation);
        }
    }
}
