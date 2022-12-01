namespace Arkanoid.Save
{
    public interface ISaveDataObject
    {
        ISaveDataContainer GetSaveDataContainer();
        void UpdateObjectFromSaveData(ISaveDataContainer data);
    }
}
