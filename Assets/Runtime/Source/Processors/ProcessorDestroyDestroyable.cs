using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Data;

namespace Runtime.Source.Processors
{
    // Class represents a system which destroys entities depending on the specified data
    sealed class ProcessorDestroyDestroyable : Processor, ITick
    {
        private readonly Group<ComponentDestroyable> groupDestroyable = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupDestroyable.length; i++)
            {
                var spawnedObj = groupDestroyable[i];
                
                var destroyableEntity = spawnedObj.ComponentDestroyable();
                
                ReleaseEntityAtCoordinate(spawnedObj, destroyableEntity);
            }
        }

        private void ReleaseEntityAtCoordinate(ent spawnedObj, ComponentDestroyable destroyable)
        {
            var destroyData = destroyable.DestroyData;
            var releaseAtCoordinate = destroyData.DestroyAtCoordinate;

            switch (destroyData.DestroyAtAxis)
            {
                case Axis.X:
                    switch (destroyData.ComparisonType)
                    {
                        case ComparisonType.Above
                            when spawnedObj.transform.position.x > releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                        case ComparisonType.Below
                            when spawnedObj.transform.position.x < releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                    }

                    break;
                case Axis.Y:
                    switch (destroyData.ComparisonType)
                    {
                        case ComparisonType.Above
                            when spawnedObj.transform.position.y > releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                        case ComparisonType.Below
                            when spawnedObj.transform.position.y < releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                    }

                    break;
                case Axis.Z:
                    switch (destroyData.ComparisonType)
                    {
                        case ComparisonType.Above
                            when spawnedObj.transform.position.z > releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                        case ComparisonType.Below
                            when spawnedObj.transform.position.z < releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                    }

                    break;
            }
        }
    }
}