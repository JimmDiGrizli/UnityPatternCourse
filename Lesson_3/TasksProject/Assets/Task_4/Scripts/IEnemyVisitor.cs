using Task_4.Enemy;

namespace Task_4
{
    public interface IEnemyVisitor
    {
        void Visit(Ork ork);
        void Visit(Human human);
        void Visit(Elf elf);
        void Visit(Enemy.Enemy enemy);
    }
}
