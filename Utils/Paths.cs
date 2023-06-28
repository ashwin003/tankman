namespace tankman.Utils;

public static class Paths
{
  public static string Normalize(string path)
  {
    path = !path.StartsWith("/") ? "/" + path : path;
    path = path.EndsWith("/") ? path.Substring(0, path.Length - 1) : path;
    return path;
  }
}