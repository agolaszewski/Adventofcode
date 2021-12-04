using System;
using System.Collections.Generic;
using System.IO;

namespace Parser
{
    public static class InputReader
    {
        public static List<T> Read<T>(string fileName, Func<string, T> parseFn)
        {
            List<T> result = new List<T>();

            using StreamReader file = new StreamReader(fileName);

            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                result.Add(parseFn(line.Trim()));
            }
            file.Close();

            return result;
        }

        public static List<T> ReadMultiLine<T>(string fileName, Func<List<string>, T> parseFn)
        {
            List<T> result = new List<T>();

            using StreamReader file = new StreamReader(fileName);

            List<string> lines = new List<string>();
            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    result.Add(parseFn(lines));
                    lines = new List<string>();
                }
                else
                {
                    lines.Add(line.Trim());
                }
            }

            if (lines.Count > 0)
            {
                result.Add(parseFn(lines));
            }

            file.Close();

            return result;
        }

        public static T ReadTo<T>(string fileName, Func<List<string>, T> parseFn)
        {
            using StreamReader file = new StreamReader(fileName);

            List<string> lines = new List<string>();
            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                lines.Add((line.Trim()));
            }
            file.Close();
            return parseFn(lines);
        }
    }
}