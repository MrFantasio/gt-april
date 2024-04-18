using System.ComponentModel.Design;
using System.Net.Http.Json;
using System.Text.Json;

namespace ConsoleApp1;

public class Palindrome
{
    private const string BaseUrl = "https://gt-code-test.azurewebsites.net/";
    private const string GetEndPoint = "api/get/";
    private const string PostEndPoint = "api/submit";
    private const string QueryParam = "<INSERT_QUERY_PARAM>";

    private static string CheckPalindromes(List<string> words)
    {
        List<string> palindromes = [];
        List<string> nonPalindromes = [];
        foreach (var word in words)
        {
            char[] charArr = word.ToLower().ToCharArray();
            Array.Reverse(charArr);
            string reversed = new string(charArr);
            if (word.ToLower() == reversed)
            {
                palindromes.Add(word);
            }
            else
            {
                nonPalindromes.Add(word);
            }
        }

        string returnString = "The following words are palindromes: ";

        if (!palindromes.Any()) return "There were no palindromes";

        foreach (var palindrome in palindromes)
        {
            returnString += $"{palindrome}, ";
        }

        var responseObject = new PalindromeDto
        {
            Palindromes = palindromes,
            NonPalindromes = nonPalindromes
        };

        PostPalindrome(responseObject);

        return returnString;
    }

    private static async void PostPalindrome(PalindromeDto palindromeDto)
    {
        var postObject = JsonSerializer.Serialize(palindromeDto);
        Console.WriteLine(postObject);
        var response = await HttpClient.PostAsJsonAsync(
            BaseUrl + PostEndPoint + "blabla" + QueryParam,
            postObject);
    }

    public static async Task<string> GetWords()
    {
        var response = await HttpClient.GetAsync(BaseUrl + GetEndPoint + "blabla" + QueryParam);
        if (response.IsSuccessStatusCode)
        {
            string jsonResult = await response.Content.ReadAsStringAsync();
            List<string>? jsonResponse = JsonSerializer.Deserialize<List<string>>(jsonResult);
            if (jsonResponse != null)
            {
                var palindromes = CheckPalindromes(jsonResponse);
                return palindromes;
            }

            throw new Exception("Something went wrong");
        }

        throw new Exception("Something went wrong");
    }

    private static HttpClient HttpClient
    {
        get
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", $"application/json");
            return httpClient;
        }
    }

    private class PalindromeDto
    {
        public List<string> Palindromes { get; set; }
        public List<string> NonPalindromes { get; set; }
    }
}