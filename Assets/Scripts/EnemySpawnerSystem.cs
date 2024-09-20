using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct EnemySpawnerSystem : ISystem
{
    private Random RandomEnemySpawnPoint;
    public void OnCreate(ref SystemState state)
    { 
        RandomEnemySpawnPoint = new Random((uint)System.Environment.TickCount);
    }

    public void OnDestroy(ref SystemState state) { }
    public void OnUpdate(ref SystemState state) 
    {
        foreach (RefRW<EnemySpawner> enemySpawner in SystemAPI.Query<RefRW<EnemySpawner>>()) 
        {
            if(enemySpawner.ValueRO.nextSpawnTime < SystemAPI.Time.ElapsedTime) 
            {
                Entity newEntity = state.EntityManager.Instantiate(enemySpawner.ValueRO.prefab);
                float RandomEnemySpawnPointX = RandomEnemySpawnPoint.NextFloat(-10f, 10f);
                float3 position = new float3(RandomEnemySpawnPointX, enemySpawner.ValueRO.spawnLocation.y, 0);
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(position));
                enemySpawner.ValueRW.nextSpawnTime = (float)SystemAPI.Time.ElapsedTime + enemySpawner.ValueRO.spawnRate;
            }
        }
    }
}
