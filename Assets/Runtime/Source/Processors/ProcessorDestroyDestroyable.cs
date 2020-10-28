using Pixeye.Actors;
using Runtime.Source.Data;
using UnityEngine;


namespace Game.Source
{
    sealed class ProcessorDestroyDestroyable : Processor, ITick
    {
        private Group<ComponentDestroyable> groupDestroyable = default;

        public void Tick(float delta)
        {
            for (int i = 0; i < groupDestroyable.length; i++)
            {
                var spawnedObj = groupDestroyable[i];
                
                var destroyableEntity = spawnedObj.ComponentDestroyable();
                if (destroyableEntity.DestroyData.DestroyAfterDelay)
                    ReleaseEntityAfter(spawnedObj, destroyableEntity);
                else ReleaseEntityAtCoordinate(spawnedObj, destroyableEntity);
            }
        }

        private void ReleaseEntityAfter(ent spawnedObj, ComponentDestroyable destroyable)
        {
            var destroyData = destroyable.DestroyData;

            if (destroyable.Lifetime >= destroyData.DestroyAfter)
            {
                destroyable.Lifetime = 0;
                spawnedObj.Release();
            }
            else destroyable.Lifetime += Time.deltaTime;
        }

        private void ReleaseEntityAtCoordinate(ent spawnedObj, ComponentDestroyable destroyable)
        {
            var destroyData = destroyable.DestroyData;
            var releaseAtCoordinate = destroyData.DestroyAtCoordinate;

            switch (destroyData.DestroyAtAxis)
            {
                case Axis.X:
                    switch (destroyData.ComparisonSign)
                    {
                        case ComparisonSign.Above
                            when spawnedObj.transform.position.x > releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                        case ComparisonSign.Below
                            when spawnedObj.transform.position.x < releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                    }

                    break;
                case Axis.Y:
                    switch (destroyData.ComparisonSign)
                    {
                        case ComparisonSign.Above
                            when spawnedObj.transform.position.y > releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                        case ComparisonSign.Below
                            when spawnedObj.transform.position.y < releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                    }

                    break;
                case Axis.Z:
                    switch (destroyData.ComparisonSign)
                    {
                        case ComparisonSign.Above
                            when spawnedObj.transform.position.z > releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                        case ComparisonSign.Below
                            when spawnedObj.transform.position.z < releaseAtCoordinate:
                            spawnedObj.Release();
                            break;
                    }

                    break;
            }
        }
    }
}