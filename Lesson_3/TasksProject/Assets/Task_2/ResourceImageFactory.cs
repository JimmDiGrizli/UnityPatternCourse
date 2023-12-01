using Task_2.Image;

namespace Task_2
{
    public abstract class ResourceImageFactory
    {
        public abstract ImageResource Get(ResourceType type);
    }
}