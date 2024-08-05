public class Playground
{
    public int LocalFunction(int x)
    {
        var fn = (int x) => x * x;

        static int add(int a, int b)
        {
            return a + b;
        }

        var res1 = fn(x);
        var res2 = fn(x + 1);
        var sum = add(res1, res2);
        return sum;
    }
}