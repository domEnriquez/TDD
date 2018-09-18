namespace Stack
{
    public interface IStack
    {
        int getSize();
        bool IsEmpty();
        int pop();
        void push(int element);
        int top();
        int? find(int element);
    }
}