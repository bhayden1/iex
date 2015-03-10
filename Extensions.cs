using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastMember;

namespace iex
{
  public static class Extensions
  {
    public static string ToCsv<T>(this IEnumerable<T> list, bool withHeaders)
    {
      var builder = new StringBuilder();
      var type = typeof(T);
      var properties = type.GetProperties().Select(r => r.Name).ToList();
      if (withHeaders)
      {
        var headers = string.Join(",", properties);
        builder.AppendLine(headers);
      }
      
      list.Select(r => ObjectAccessor.Create(r))
        .ToList()
        .ForEach(r =>
        {
          var values = properties.Select(property => r[property].ToString()).ToList();
          var csvValues = string.Join(",", values);
          builder.AppendLine(csvValues);
        });

      return builder.ToString();
    }
  }
}
