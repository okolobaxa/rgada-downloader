namespace RgadaDownloader;

public class PageParser
{
    public static async Task<DownloadInfo> ParserPage(Uri uri)
    {
        var client = new HttpClient();

        try
        {
            var body = await client.GetStringAsync(uri);

            var data = Parse(body);
            data.BasePath = ParseBasePath(uri);

            return data;
        }
        catch (Exception)
        {
            return null;
        }
    }

    private static string ParseBasePath(Uri uri)
    {
        var left = uri.GetLeftPart(UriPartial.Path);
        var basePath = left.Remove(left.LastIndexOf('/') + 1);

        return basePath;
    }

    private static DownloadInfo Parse(string body)
    {
        var downloadInfo = new DownloadInfo();

        const string token = "data-largeim=\"";

        var position = 0;
        while (position >= 0)
        {
            //<li><a href="#"><img src="../../3/23/36.jpg" data-large="2/1209-opis_231i/0037.jpg" data-largeim="1/1209-opis_231i/0037.jpg" data-razmfile= "771"  alt="image37 data-description=" /></a></li>
            position = body.IndexOf(token, position + token.Length);
            if (position == -1)
            {
                break;
            }

            var start = position + token.Length;
            var end = body.IndexOf("\"", start);

            var str = body[start..end];

            var parts = str.Split('/');

            downloadInfo.Links.Add(new LinkInfo(str, parts.Last()));
        }

        var firstParts = downloadInfo.Links.First().Url.Split('/');
        downloadInfo.Name = firstParts[^2];

        return downloadInfo;
    }
}

public class DownloadInfo
{
    public string Name { get; set; }

    public string BasePath { get; set; }

    public List<LinkInfo> Links { get; } = new();
}

public record LinkInfo(string Url, string FileName);