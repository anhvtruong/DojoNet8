using System.Collections.Frozen;

namespace CSharp12;

internal class CollectionExpressions
{
    public static void Test()
    {
        // Create an array:
        char[] a = ['a', 'b', 'c', 'd', 'e', 'f'];

        // Create a list:
        List<string> b = ["cdefhijk", "abcdefhij", "jk"];

        // Create a span:
        Span<char> c = ['j', 'k'];
        ReadOnlySpan<char> ic = [.. a, 'h', 'i', .. c];

        Console.WriteLine(ic[2..].ToString() == b[0]); // skip two first elements
        Console.WriteLine(ic[..^1].ToString() == b[1]); // excepts last element
        Console.WriteLine(ic[^2..].ToString() == b[2]); // last two elements

        // Create a jagged 2D array:
        int[][] twoD = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

        // Create a jagged 2D array from variables:
        int[] row0 = [1, 2, 3];
        int[] row1 = [4, 5, 6];
        int[] row2 = [7, 8, 9];
        int[][] twoDFromVariables = [row0, row1, row2];

        // Create *EMPTY* dictionary
        Dictionary<string, int> dict = [];
        var s = dict.ToFrozenDictionary();

        // Note: var x = [] doesn't work!
    }

    public async void AsyncTest()
    {
        User[] users = await GetUsersAsync() ?? [];
    }

    public Task<User[]?> GetUsersAsync()
    {
        return Task.FromResult<User[]?>([
            new User("user1"),
            new User("user2"),
            new User("user3"),
        ]);
    }
}

record User(string Name) { }