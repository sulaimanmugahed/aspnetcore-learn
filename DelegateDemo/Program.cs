



static int GetNumber(int number)
=> 8;



Print((c, h) =>
{
    return c + h;
});


static void Print(Func<int, int, int> deleg)
{
    var result = deleg(5, 7);

    var result2 = deleg(7, 5);

}




public class Book
{

}