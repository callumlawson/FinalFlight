using Entitas;

namespace Assets.Sources.Init
{
    class CreateAircraftSystem : IInitializeSystem, ISetPool
    {
        private Pool systemPool;

        public void SetPool(Pool pool)
        {
            this.systemPool = pool;
        }

        public void Initialize()
        {
            for (int i = 0; i < 4; i++)
            {
                systemPool.CreateEntity().AddName("Spitfire" + i).AddHealth(95).AddAirframe(129);
            }
        }
    }
}

