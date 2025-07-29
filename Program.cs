using CompareFollowers;
using System.Text.Json;


Console.WriteLine("Enter the directory path of the JSONs:");
var directoryPath = Console.ReadLine();

List<string> followers;
using (StreamReader reader = new StreamReader(directoryPath + "/followers_1.json"))
{
    var json = JsonSerializer.Deserialize<List<JsonFollower>>(reader.ReadToEnd());
    followers = json.SelectMany(f => f.string_list_data.Select(s => s.value)).ToList();
    reader.Close();
}

List<string> following;
using (StreamReader reader = new StreamReader(directoryPath + "/following.json"))
{
    var json = JsonSerializer.Deserialize<JsonFollowing>(reader.ReadToEnd());
    following = json.relationships_following.SelectMany(f => f.string_list_data.Select(s => s.value)).ToList();
    reader.Close();
}

List<string> followingNotInFollowers;

followingNotInFollowers = following.Except(followers).ToList();

Console.WriteLine(string.Join("\n", followingNotInFollowers));
Console.ReadKey();