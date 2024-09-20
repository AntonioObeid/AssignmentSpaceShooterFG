using UnityEngine;
using Unity.Entities;

public class EnemyObjectAuthoring : MonoBehaviour
{
    public float EnemyObjectMovementSpeed;

    class EnemyAuthoringBaker : Baker<EnemyObjectAuthoring>
    {
        public override void Bake(EnemyObjectAuthoring authoring)
        {
            Entity enemyEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(enemyEntity, new EnemyObjectMoveSpeed { Value = authoring.EnemyObjectMovementSpeed });
        }
    }
}

public struct EnemyObjectTag : IComponentData { }

public struct EnemyObjectMoveSpeed : IComponentData
{
    public float Value;
}
