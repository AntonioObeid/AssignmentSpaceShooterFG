using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate;

    class EnemySpawnerBaker : Baker<EnemySpawnerAuthoring>
    {
        public override void Bake(EnemySpawnerAuthoring authoring)
        {
            float3 EnemySpawnLocation = authoring.transform.position;
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new EnemySpawner
            {
                prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
                spawnLocation = new float2(EnemySpawnLocation.x, EnemySpawnLocation.y),
                nextSpawnTime = 0,
                spawnRate = authoring.spawnRate
            });
        }
    }
}
