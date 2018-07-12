namespace UsefulSites.DataAccess.Data
{
    public class ResourceCategory : BaseDataEntity
    {
        public string Name { get; set; }

        public ResourceCategory()
        {

        }

        public ResourceCategory(string name)
        {
            Name = name;
        }
    }
}