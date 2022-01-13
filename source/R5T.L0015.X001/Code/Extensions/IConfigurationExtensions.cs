using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;


namespace R5T.L0015.X001
{
    public static class IConfigurationExtensions
    {
        public static void DescribeToStringBuilder(this IConfiguration configuration,
            StringBuilder stringBuilder)
        {
            var lines = new List<string>();

            foreach (var pair in configuration.AsEnumerable())
            {
                if (pair.Value is object)
                {
                    lines.Add($"{pair.Key}: {pair.Value}");
                }
            }

            var orderedLines = lines
                .OrderAlphabetically()
                ;

            foreach (var line in orderedLines)
            {
                stringBuilder.AppendLine(line);
            }
        }

        public static async Task DescribeToTextFile(this IConfiguration configuration,
            string textFilePath)
        {
            var stringBuilder = new StringBuilder();

            configuration.DescribeToStringBuilder(stringBuilder);

            var text = stringBuilder.ToString();

            var fileWriter = StreamWriterHelper.NewWrite(textFilePath);

            await fileWriter.WriteAsync(text);
            await fileWriter.FlushAsync();
        }
    }
}
