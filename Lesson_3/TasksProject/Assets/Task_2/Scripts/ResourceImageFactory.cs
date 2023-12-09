using Task_2.Scripts.Images;

namespace Task_2.Scripts
{
    public abstract class ResourceImageFactory
    {
        public abstract ImageResource Get(ResourceType type);
    }
}