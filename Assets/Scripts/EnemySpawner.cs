using Unity.Entities;
using Unity.Mathematics;

public struct EnemySpawner : IComponentData
{
    public Entity prefab;
    public float2 spawnLocation;
    public float nextSpawnTime;
    public float spawnRate;
}
