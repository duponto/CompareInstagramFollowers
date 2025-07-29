namespace CompareFollowers;
public class JsonFollowing
{
    public List<JsonFollower> relationships_following { get; set; }
}
public class JsonFollower
{
    public string title { get; set; }
    public List<object> media_list_data { get; set; }
    public List<StringListData> string_list_data { get; set; }

}
public class StringListData
{
    public string href { get; set; }
    public string value { get; set; }
    public long timestamp { get; set; }
}